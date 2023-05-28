using DiplomaProject.Classes;
using DiplomaProject.Entities;
using DiplomaProject.Pages.Product;
using DiplomaProject.Windows;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiplomaProject.Pages.ProductionPlan
{
    /// <summary>
    /// Логика взаимодействия для ProductionPlanPage.xaml
    /// </summary>
    public partial class ProductionPlanPage : Page
    {
        ListEvents content = new ListEvents();
        private DiplomaDBEntities context;
        private Entities.ProductionPlan[] productionPlan;
        private int pageIndex = 1;
        private int countItem;
        private int pageCount;
        public Frame masterFrame;
        public bool result;

        public ProductionPlanPage(Frame frame)
        {
            InitializeComponent();
            masterFrame = frame;
            LoadData();
        }

        public void LoadData()
        {
            countItem = content.SetListContentSize(countItem);
            context = new DiplomaDBEntities();
            productionPlan = context.ProductionPlans.ToArray();
            productionPlan = FindInfo(productionPlan);
            productionPlan = FilterInfo(productionPlan);
            if (productionPlan.Length != 0)
            {
                productionPlan = SortInfo(productionPlan);
                lvInfo.Visibility = Visibility.Visible;
                lvInfo.ItemsSource = productionPlan.Skip((pageIndex - 1) * countItem).Take(countItem).ToList();
                tbCurrentEntries.Text = lvInfo.Items.Count.ToString();
                tbTotalEntries.Text = context.ProductionPlans.Count().ToString();
            }
            else
            {
                lvInfo.Visibility = Visibility.Hidden;
                tbCurrentEntries.Text = "0";
            }
            pageCount = (int)Math.Ceiling((decimal)productionPlan.Length / (decimal)countItem);
            tbPages.Text = pageIndex + " / " + pageCount;
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
                tbPages.Text = pageIndex + " / " + pageCount;
                LoadData();
            }
        }

        private Entities.ProductionPlan[] FilterInfo(Entities.ProductionPlan[] productionPlans)
        {
            if (cmbFilter.SelectedIndex == 0)
            {
            }
            if (cmbFilter.SelectedIndex == 1)
            {
                productionPlans = productionPlan.Where(x => x.finishDate < DateTime.Today).ToArray();
            }
            if (cmbFilter.SelectedIndex == 2)
            {
                productionPlans = productionPlan.Where(x => x.startDate < DateTime.Today && x.finishDate > DateTime.Today).ToArray();
            }
            if (cmbFilter.SelectedIndex == 3)
            {
                productionPlans = productionPlan.Where(x => x.startDate > DateTime.Today).ToArray();
            }
            return productionPlans;
        }

        private Entities.ProductionPlan[] SortInfo(Entities.ProductionPlan[] productionPlans)
        {
            if (cmbSort.SelectedIndex == 0)
            {
            }
            if (cmbSort.SelectedIndex == 1)
            {
                productionPlans = productionPlans.OrderBy(x => x.name).ToArray();
            }
            if (cmbSort.SelectedIndex == 2)
            {
                productionPlans = productionPlans.OrderByDescending(x => x.name).ToArray();
            }
            return productionPlans;
        }

        private Entities.ProductionPlan[] FindInfo(Entities.ProductionPlan[] productionPlans)
        {
            if (tbFindText.Text != null)
            {
                productionPlans = productionPlan.Where(x => x.name.ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                if (productionPlans.Length == 0)
                {
                    productionPlans = productionPlan.Where(x => x.description.ToString().ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                    if (productionPlans.Length == 0)
                    {
                        productionPlans = productionPlan.Where(x => x.startDate.ToString().ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                        if (productionPlans.Length == 0)
                        {
                            productionPlans = productionPlan.Where(x => x.finishDate.ToString().ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                        }
                    }
                }
            }
            return productionPlans;
        }

        private void tbFindText_TextChanged(object sender, TextChangedEventArgs e)
        {
            pageIndex = 1;
            LoadData();
        }

        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = 1;
            LoadData();
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex > 1)
            {
                pageIndex--;
                LoadData();
            }
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (pageIndex < pageCount)
            {
                pageIndex++;
                LoadData();
            }
        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {
            pageIndex = pageCount;
            LoadData();
        }

        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Navigate(new ProductionPlanPageInfo(masterFrame, context, (sender as Button).DataContext as Entities.ProductionPlan, "Редактирование текущего плана прозводства"));
            LoadData();
        }

        private void DeleteInfo_Click(object sender, RoutedEventArgs e)
        {
            new CustomMessageBox("Вы уверены?", "Вы точно хотите удалить данный план производства?", "Да", "Нет", 2, true).ShowDialog();
            if (ListEvents.incidentResult is true)
            {
                new CustomMessageBox("Успех", "Удаление плана производства прошло успешно!", "ОК", "Отменить", 1, true).ShowDialog();
                if (ListEvents.incidentResult is true)
                {
                    var selectedElement = (sender as Button).DataContext as Entities.ProductionPlan;
                    context.ProductionPlans.Remove(selectedElement);
                    context.SaveChanges();
                    LoadData();
                }
            }
            else
            {
                LoadData();
            }
        }

        private void AddInfo_Click(object sender, RoutedEventArgs e)
        {
            var item = new Entities.ProductionPlan();
            context.ProductionPlans.Add(item);
            masterFrame.Navigate(new ProductionPlanPageInfo(masterFrame, context, item, "Создание нового плана производства"));
            LoadData();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
            pageIndex = 1;
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
            pageIndex = 1;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Entities.ProductionPlan[] productionPlans = context.ProductionPlans.ToArray();
            Entities.Product product;
            Entities.ProductionPlanProduct productionPlanProduct;
            foreach (Entities.ProductionPlan item in productionPlans)
            {
                if (item.calculated is false)
                {
                    if (item.finishDate <= DateTime.Today)
                    {
                        Entities.ProductionPlanProduct[] planProducts = context.ProductionPlanProducts.Where(x => x.id_plan == item.id).ToArray();
                        foreach (Entities.ProductionPlanProduct currentProduct in planProducts)
                        {
                            //productionPlanProduct = context.ProductionPlanProducts.Where(x => x.id_plan == item.id).FirstOrDefault();
                            product = context.Products.Where(x => x.id == currentProduct.id_product).FirstOrDefault();
                            product.count = product.count + currentProduct.productCount;
                        }
                        item.calculated = true;
                        context.SaveChanges();
                    }
                }
            }
        }

        private void ChangePage_Click(object sender, RoutedEventArgs e)
        {
            if (tbSelectedPage.Text != "")
            {
                if (int.TryParse(tbSelectedPage.Text, out int result))
                {
                    int selectedPage = Convert.ToInt32(tbSelectedPage.Text);
                    if (selectedPage <= 0 || selectedPage > pageCount)
                    {
                        new CustomMessageBox("Предупреждение!", "Число должно быть больше нуля и не превышать максимальное количество страниц!", "ОК", "Нет", 3, false).ShowDialog();
                    }
                    else
                    {
                        pageIndex = selectedPage;
                        LoadData();
                    }
                }
                else
                {
                    new CustomMessageBox("Предупреждение!", "Номер страницы должен быть целочисленным!", "ОК", "Нет", 3, false).ShowDialog();
                }
                tbSelectedPage.Text = "";
            }
            else
            {
                new CustomMessageBox("Предупреждение!", "Не указана страница!", "ОК", "Нет", 3, false).ShowDialog();
            }
        }

        private void tbSelectedPage_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
