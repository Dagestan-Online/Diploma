using DiplomaProject.Classes;
using DiplomaProject.Entities;
using DiplomaProject.Pages.Employee;
using DiplomaProject.Windows;
using System;
using System.Collections.Generic;
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

namespace DiplomaProject.Pages.Product
{
    /// <summary>
    /// Логика взаимодействия для ProductPage.xaml
    /// </summary>
    public partial class ProductPage : Page
    {
        ListEvents content = new ListEvents();
        private DiplomaDBEntities context;
        private Entities.Product[] product;
        private int pageIndex = 1;
        private int countItem;
        private int pageCount;
        public Frame masterFrame;
        public bool result;

        public ProductPage(Frame frame)
        {
            InitializeComponent();
            masterFrame = frame;
            LoadData();
        }

        public void LoadData()
        {
            countItem = content.SetListContentSize(countItem);
            context = new DiplomaDBEntities();
            product = context.Products.ToArray();
            product = FindInfo(product);
            product = FilterInfo(product);
            if (product.Length != 0)
            {
                product = SortInfo(product);
                lvInfo.Visibility = Visibility.Visible;
                lvInfo.ItemsSource = product.Skip((pageIndex - 1) * countItem).Take(countItem).ToList();
                tbCurrentEntries.Text = lvInfo.Items.Count.ToString();
                tbTotalEntries.Text = context.Products.Count().ToString();
            }
            else
            {
                lvInfo.Visibility = Visibility.Hidden;
                tbCurrentEntries.Text = "0";
            }
            pageCount = (int)Math.Ceiling((decimal)product.Length / (decimal)countItem);
            tbPages.Text = pageIndex + " / " + pageCount;
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
                tbPages.Text = pageIndex + " / " + pageCount;
                LoadData();
            }
        }

        //фильтрация данных из таблицы
        private Entities.Product[] FilterInfo(Entities.Product[] products)
        {
            if (cmbFilter.SelectedIndex == 0)
            {
            }
            if (cmbFilter.SelectedIndex == 1) //выбор нужного фильтра
            {
                products = product.Where(x => x.count < 100).ToArray(); //выборка данных, походящих под фильтр
            }
            if (cmbFilter.SelectedIndex == 2)
            {
                products = product.Where(x => x.count < 200).ToArray();
            }
            if (cmbFilter.SelectedIndex == 3)
            {
                products = product.Where(x => x.count < 300).ToArray();
            }
            if (cmbFilter.SelectedIndex == 4)
            {
                products = product.Where(x => x.count < 400).ToArray();
            }
            if (cmbFilter.SelectedIndex == 5)
            {
                products = product.Where(x => x.count < 500).ToArray();
            }
            return products; //возврат результата
        }

        //сортировка данных из таблицы
        private Entities.Product[] SortInfo(Entities.Product[] products)
        {
            if (cmbSort.SelectedIndex == 0)
            {
            }
            if (cmbSort.SelectedIndex == 1) //выбор нужного метода сортировки
            {
                products = products.OrderBy(x => x.name).ToArray(); //сортировка данных
            }
            if (cmbSort.SelectedIndex == 2)
            {
                products = products.OrderByDescending(x => x.name).ToArray();
            }
            return products; //возврат результата
        }

        //поиск данных из таблицы
        private Entities.Product[] FindInfo(Entities.Product[] products)
        {
            if (tbFindText.Text != null) //проверка на пустоту поля для поиска
            {
                products = product.Where(x => x.name.ToLower().
                Contains(tbFindText.Text.ToLower())).ToArray(); //поиск данных, в которых есть строка поиска
                if (products.Length == 0)
                {
                    products = product.Where(x => x.count.ToString().ToLower().
                    Contains(tbFindText.Text.ToLower())).ToArray();
                    if (products.Length == 0)
                    {
                        products = product.Where(x => x.description.ToLower().
                        Contains(tbFindText.Text.ToLower())).ToArray();
                        if (products.Length == 0)
                        {
                            products = product.Where(x => x.Material.name.ToLower().
                            Contains(tbFindText.Text.ToLower())).ToArray();
                            if (products.Length == 0)
                            {
                                products = product.Where(x => x.ProductType.name.ToLower().
                                Contains(tbFindText.Text.ToLower())).ToArray();
                            }
                        }
                    }
                }
            }
            return products; //возврат результата
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

        //редактирование существующих данных
        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Navigate(new ProductPageInfo(masterFrame, context, 
                (sender as Button).DataContext as Entities.Product, 
                "Редактирование текущего изделия")); //перемещение на новую страницу с добавлением данных
            LoadData(); // обновление таблицы с данными
        }

        //удаление существующих данных
        private void DeleteInfo_Click(object sender, RoutedEventArgs e)
        {
            new CustomMessageBox("Вы уверены?", "Вы точно хотите удалить данное изделие?", 
                "Да", "Нет", 2, true).ShowDialog(); //диалоговое окно для подтверждения действия
            if (ListEvents.incidentResult is true) // проверка подтверждения
            {
                new CustomMessageBox("Успех", "Удаление изделия прошло успешно!", 
                    "ОК", "Отменить", 1, true).ShowDialog(); //диалоговое окно, оповещающее об успешности действия
                                                             //здесь можно отменить действие
                if (ListEvents.incidentResult is true) //проверка ответа пользователя
                {
                    try
                    {
                        var selectedElement = (sender as Button).DataContext as Entities.Product; //взятие выбранного контекста данных
                        context.Products.Remove(selectedElement); //удаление данных
                        context.SaveChanges(); //сохранение изменений
                        LoadData(); //обновление таблицы с данными
                    }
                    catch (Exception ex)
                    {
                        new CustomMessageBox("Внимание!", ex.Message, 
                            "ОК", "Назад", 4, false).ShowDialog(); //если есть ошибка, появится окно, сообщающее об этом
                    }
                }
            }
            else
            {
                LoadData(); //обновление таблицы с данными
            }
        }

        //добавление новых данных
        private void AddInfo_Click(object sender, RoutedEventArgs e)
        {
            var item = new Entities.Product(); //создание новой переменной необходимого типа
            context.Products.Add(item); //создание контекста для добавления данных
            masterFrame.Navigate(new ProductPageInfo(masterFrame, context, 
                item, "Создание нового изделия")); //перемещение на новую страницу с добавлением данных
            LoadData(); // обновление таблицы с данными
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData(); //обновление таблицы с данными
            pageIndex = 1; //присвоение номера для страницы
        }

        private void cmbFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData(); //обновление таблицы с данными
            pageIndex = 1; //присвоение номера для страницы
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
