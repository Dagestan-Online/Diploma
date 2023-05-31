using DiplomaProject.Classes;
using DiplomaProject.Entities;
using DiplomaProject.Pages.Post;
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

namespace DiplomaProject.Pages.Employee
{
    /// <summary>
    /// Логика взаимодействия для EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Page
    {
        ListEvents content = new ListEvents();
        private DiplomaDBEntities context;
        private Entities.Employee[] employee;
        private int pageIndex = 1;
        private int countItem;
        private int pageCount;
        public Frame masterFrame;
        public bool result;

        public EmployeePage(Frame frame)
        {
            InitializeComponent();
            masterFrame = frame;
            LoadData();
        }

        public void LoadData()
        {
            countItem = content.SetListContentSize(countItem);
            context = new DiplomaDBEntities();
            employee = context.Employees.ToArray();
            employee = FindInfo(employee);
            if (employee.Length != 0)
            {
                employee = SortInfo(employee);
                lvInfo.Visibility = Visibility.Visible;
                lvInfo.ItemsSource = employee.Skip((pageIndex - 1) * countItem).Take(countItem).ToList();
                tbCurrentEntries.Text = lvInfo.Items.Count.ToString();
                tbTotalEntries.Text = context.Employees.Count().ToString();
            }
            else
            {
                lvInfo.Visibility = Visibility.Hidden;
                tbCurrentEntries.Text = "0";
            }
            pageCount = (int)Math.Ceiling((decimal)employee.Length / (decimal)countItem); //posts.Length / countItem * 1.0
            tbPages.Text = pageIndex + " / " + pageCount;
            if (pageIndex > pageCount)
            {
                pageIndex = pageCount;
                tbPages.Text = pageIndex + " / " + pageCount;
                LoadData();
            }
        }

        private Entities.Employee[] SortInfo(Entities.Employee[] employees)
        {
            if (cmbSort.SelectedIndex == 0)
            {
            }
            if (cmbSort.SelectedIndex == 1)
            {
                employees = employees.OrderBy(x => x.name).ToArray();
            }
            if (cmbSort.SelectedIndex == 2)
            {
                employees = employees.OrderByDescending(x => x.name).ToArray();
            }
            return employees;
        }

        private Entities.Employee[] FindInfo(Entities.Employee[] employees)
        {
            if (tbFindText.Text != null)
            {
                employees = employee.Where(x => x.name.ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                if (employees.Length == 0)
                {
                    employees = employee.Where(x => x.lastname.ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                    if (employees.Length == 0)
                    {
                        employees = employee.Where(x => x.middlename.ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                        if (employees.Length == 0)
                        {
                            employees = employee.Where(x => x.phone.ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                            if (employees.Length == 0)
                            {
                                employees = employee.Where(x => x.email.ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                                if (employees.Length == 0)
                                {
                                    employees = employee.Where(x => x.birthDate.ToString().ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                                    if (employees.Length == 0)
                                    {
                                        employees = employee.Where(x => x.employmentDate.ToString().ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                                        if (employees.Length == 0)
                                        {
                                            employees = employee.Where(x => x.Post.name.ToLower().Contains(tbFindText.Text.ToLower())).ToArray();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }    
            }
            return employees;
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
            masterFrame.Navigate(new EmployeePageInfo(masterFrame, context, (sender as Button).DataContext as Entities.Employee, "Редактирование текущего сотрудника"));
            LoadData();
        }

        private void DeleteInfo_Click(object sender, RoutedEventArgs e)
        {
            new CustomMessageBox("Вы уверены?", "Вы точно хотите удалить данного сотрудника?", "Да", "Нет", 2, true).ShowDialog();
            if (ListEvents.incidentResult is true)
            {
                new CustomMessageBox("Успех", "Удаление сотрудника прошло успешно!", "ОК", "Отменить", 1, true).ShowDialog();
                if (ListEvents.incidentResult is true)
                {
                    var selectedElement = (sender as Button).DataContext as Entities.Employee;
                    context.Employees.Remove(selectedElement);
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
            var item = new Entities.Employee();
            context.Employees.Add(item);
            masterFrame.Navigate(new EmployeePageInfo(masterFrame, context, item, "Создание нового сотрудника"));
            LoadData();
        }

        private void cmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LoadData();
            pageIndex = 1;
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
            try
            {
                if (!Char.IsDigit(e.Text, 0))
                {
                    e.Handled = true;
                }
            }
            catch
            {

            }
        }
    }
}
