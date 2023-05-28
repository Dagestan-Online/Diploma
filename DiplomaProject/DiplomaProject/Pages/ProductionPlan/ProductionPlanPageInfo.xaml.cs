using DiplomaProject.Classes;
using DiplomaProject.Entities;
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

namespace DiplomaProject.Pages.ProductionPlan
{
    /// <summary>
    /// Логика взаимодействия для ProductionPlanPageInfo.xaml
    /// </summary>
    public partial class ProductionPlanPageInfo : Page
    {
        ComboBox[] massComboBoxs = new ComboBox[100];
        ComboBox[] massCmbEmployees = new ComboBox[100];
        TextBox[] massTextBoxs = new TextBox[100];
        int indexNameCmbProducts = 1;
        int indexNameCmbEmployees = 1;

        int indexConnectionProduct = 1;
        int indexConnectionEmployee = 1;
        ProductionPlanProduct[] connectionProduct;
        ProductionPlanEmployee[] connectionEmployee;

        DiplomaDBEntities db;
        Frame masterFrame;
        string message = "";
        Entities.ProductionPlan info;

        public ProductionPlanPageInfo(Frame frame, DiplomaDBEntities entities, Entities.ProductionPlan productionPlan, string title)
        {
            InitializeComponent();
            tblTitle.Text = title;
            masterFrame = frame;
            DataContext = productionPlan;
            db = entities;
            chbCalculated.IsChecked = false;
            info = this.DataContext as Entities.ProductionPlan;

            if (tblTitle.Text == "Редактирование текущего плана прозводства")
            {
                UpdateFillMass();
            }

            massTextBoxs[0] = tbCount;
            massComboBoxs[0] = cbProduct;
            massCmbEmployees[0] = cbEmployee;
            cbEmployee.ItemsSource = db.Employees.ToList();
            cbProduct.ItemsSource = db.Products.ToList();
        }

        public void UpdateFillMass()
        {
            connectionProduct = db.ProductionPlanProducts.Where(b => b.id_plan == info.id).ToArray();
            connectionEmployee = db.ProductionPlanEmployees.Where(b => b.id_plan == info.id).ToArray();

            cbProduct.SelectedIndex = (int)(connectionProduct[0].id_product - 1);
            tbCount.Text = connectionProduct[0].productCount.ToString();

            cbEmployee.SelectedIndex = (int)(connectionEmployee[0].id_employee - 1);

            for (; indexConnectionProduct < connectionProduct.Length; indexConnectionProduct++)
            {
                ProductCompletion();
            }
            for (; indexConnectionEmployee < connectionEmployee.Length; indexConnectionEmployee++)
            {
                EmployeeCompletion();
            }
        }

        public void EmployeeCompletion()
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Name = "cbNewEmployee" + indexNameCmbEmployees;
            indexNameCmbEmployees++;
            comboBox.DisplayMemberPath = "email";
            comboBox.Margin = new Thickness(10, 5, 10, 0);
            comboBox.ItemsSource = db.Employees.ToList();
            comboBox.SelectedIndex = (int)(connectionEmployee[indexConnectionEmployee].id_employee - 1);
            comboBox.Width = 120;
            comboBox.Height = 25;
            comboBox.Template = (ControlTemplate)comboBox.FindResource("CustomComboBoxTemplate");
            massCmbEmployees[indexNameCmbEmployees - 1] = comboBox;
            panelEmployees.Children.Add(comboBox);
        }

        public void ProductCompletion()
        {
            ComboBox comboBox = new ComboBox();
            TextBox textBox = new TextBox();
            comboBox.Name = "cbNewProduct" + indexNameCmbProducts;
            textBox.Name = "cbNewCount" + indexNameCmbProducts;
            indexNameCmbProducts++;
            comboBox.DisplayMemberPath = "name";
            comboBox.Margin = new Thickness(10, 5, 10, 0);
            comboBox.ItemsSource = db.Products.ToList();
            comboBox.SelectedIndex = (int)(connectionProduct[indexConnectionProduct].id_product - 1);
            comboBox.Width = 120;
            comboBox.Height = 25;
            comboBox.Template = (ControlTemplate)comboBox.FindResource("CustomComboBoxTemplate");
            textBox.Text = connectionProduct[indexConnectionProduct].productCount.ToString();
            textBox.VerticalAlignment = VerticalAlignment.Center;
            textBox.HorizontalAlignment = HorizontalAlignment.Center;
            textBox.Margin = new Thickness(0, 5, 0, 0);
            textBox.Padding = new Thickness(5, 1, 5, 0);
            textBox.Width = 80;
            textBox.Height = 25;
            textBox.PreviewTextInput += tbCount_PreviewTextInput;
            massComboBoxs[indexNameCmbProducts - 1] = comboBox;
            massTextBoxs[indexNameCmbProducts - 1] = textBox;
            panelProducts.Children.Add(comboBox);
            panelCount.Children.Add(textBox);
        }

        private void BtnSaveInfo_Click(object sender, RoutedEventArgs e)
        {
            if (massTextBoxs[0].Text == "" || massTextBoxs[0].Text == "0" || massComboBoxs[0].Text == "")
            {
                message += "Не все изделия или их количество указаны\n";
            }
            if (massCmbEmployees[0].Text == "")
            {
                message += "Не все сотрудники указаны\n";
            }
            for (int i = 0; i < indexNameCmbProducts - 1; i++)
            {
                if (massComboBoxs[i].Text == massComboBoxs[++i].Text || massComboBoxs[i].Text == "")
                {
                    message += "Указаны повторяющиеся изделия\n";
                    break;
                }

            }
            for (int i = 0; i < indexNameCmbEmployees - 1; i++)
            {
                if (massCmbEmployees[i].Text == massCmbEmployees[++i].Text || massCmbEmployees[i].Text == "")
                {
                    message += "Указаны повторяющиеся сотрудники или не указаны в целом\n";
                    break;
                }

            }
            for (int i = 0; i < indexNameCmbProducts; i++)
            {
                if (massTextBoxs[i].Text == "" || massTextBoxs[i].Text == "0")
                {
                    message += "Не все количества изделий указаны\n";
                    break;
                }
                string word = massTextBoxs[i].Text;
                if (!int.TryParse(massTextBoxs[i].Text, out int result))
                {
                    message += "Количество изделий должно быть целочисленным\n";
                    break;
                }
            }

            if (info.name == null)
                message += "Наименование плана производства не указано\n";
            if (info.description == null)
                info.description = "Отсутствует";
            if (info.startDate == null)
                message += "Дата начала плана производства не указана\n";
            if (info.finishDate == null)
                message += "Дата завершения плана производства не указана\n";
            if (dpStart.SelectedDate > dpFinish.SelectedDate)
                message += "Дата начала не может быть больше даты завершения\n";
            ///проверки сверху

            if (message == "")
            {
                Entities.ProductionPlan productionPlan = new Entities.ProductionPlan()
                {
                    name = tbName.Text //info.name
                };
                if (tblTitle.Text == "Редактирование текущего плана прозводства")
                {
                    db.ProductionPlanProducts.RemoveRange(connectionProduct);
                    db.ProductionPlanEmployees.RemoveRange(connectionEmployee);
                    db.SaveChanges();
                }
                Entities.ProductionPlan authProductionPlan = null;
                Entities.Product authProduct = null;
                Entities.Employee authEmployee = null;
                using (Entities.DiplomaDBEntities context = db)
                {
                    authProductionPlan = context.ProductionPlans.Where(b => b.name == tbName.Text).FirstOrDefault();
                    /*if (authProductionPlan != null)
                    {
                        MessageBox.Show("Такой план производства уже есть");
                        return;
                    }*/
                    try
                    {
                        context.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }

                    authProductionPlan = context.ProductionPlans.Where(b => b.name == tbName.Text).FirstOrDefault();

                    if (authProductionPlan != null)
                    {
                        for (int i = 0; i < indexNameCmbProducts; i++)
                        {

                            if (massComboBoxs[i] != null)
                            {
                                var nowText = massComboBoxs[i].Text;
                                authProduct = context.Products.Where(b => b.name == nowText).FirstOrDefault();
                                if (authProduct != null)
                                {
                                    ProductionPlanProduct productionPlanProduct = new ProductionPlanProduct();
                                    productionPlanProduct.id_product = authProduct.id;
                                    productionPlanProduct.id_plan = info.id;
                                    nowText = massTextBoxs[i].Text.Trim();
                                    productionPlanProduct.productCount = Convert.ToDouble(nowText);
                                    context.ProductionPlanProducts.Add(productionPlanProduct);
                                    context.SaveChanges();
                                }
                            }
                        }

                        for (int i = 0; i < indexNameCmbEmployees; i++)
                        {
                            if (massCmbEmployees[i] != null)
                            {
                                var nowText = massCmbEmployees[i].Text;
                                authEmployee = context.Employees.Where(b => b.email == nowText).FirstOrDefault();
                                if (authEmployee != null)
                                {
                                    ProductionPlanEmployee productionPlanEmployee = new ProductionPlanEmployee();
                                    productionPlanEmployee.id_employee = authEmployee.id;
                                    productionPlanEmployee.id_plan = info.id;
                                    context.ProductionPlanEmployees.Add(productionPlanEmployee);
                                    context.SaveChanges();
                                }
                            }
                        }
                        new CustomMessageBox("Успех!", "Сохранение плана производства прошло успешно!", "ОК", "Отменить", 1, false).ShowDialog();
                        if (tblTitle.Text == "Редактирование текущего плана прозводства")
                            UpdateFillMass();
                        CloseInfoAddPage_Click(sender, e);
                    }
                }
            }
            else
            {
                //MessageBox.Show("Заполните поля");
                new CustomMessageBox("Внимание!", message, "ОК", "Назад", 3, false).ShowDialog();
                message = "";
            }
        }

        private void CloseInfoAddPage_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Navigate(new ProductionPlanPage(masterFrame));
        }

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            Button pressedButton = new Button();
            pressedButton = (Button)sender;
            switch (pressedButton.Content)
            {
                case "+":
                    if (indexNameCmbProducts < 10)
                    {
                        ComboBox comboBox = new ComboBox();
                        TextBox textBox = new TextBox();
                        comboBox.Name = "cbNewProduct" + indexNameCmbProducts;
                        textBox.Name = "cbNewCount" + indexNameCmbProducts;
                        indexNameCmbProducts++;
                        comboBox.DisplayMemberPath = "name";
                        comboBox.Margin = new Thickness(10, 5, 10, 0);
                        comboBox.ItemsSource = db.Products.ToList();
                        comboBox.SelectedIndex = 0;
                        comboBox.Width = 120;
                        comboBox.Height = 25;
                        comboBox.Template = (ControlTemplate)comboBox.FindResource("CustomComboBoxTemplate");
                        textBox.VerticalAlignment = VerticalAlignment.Center;
                        textBox.HorizontalAlignment = HorizontalAlignment.Center;
                        textBox.Margin = new Thickness(0, 5, 0, 0);
                        textBox.Padding = new Thickness(5, 1, 5, 0);
                        textBox.Width = 80;
                        textBox.Height = 25;
                        textBox.PreviewTextInput += tbCount_PreviewTextInput;
                        massComboBoxs[indexNameCmbProducts - 1] = comboBox;
                        massTextBoxs[indexNameCmbProducts - 1] = textBox;
                        panelProducts.Children.Add(comboBox);
                        panelCount.Children.Add(textBox);
                    }
                    else
                    {
                        new CustomMessageBox("Внимание!", "Достигнут лимит в добавлении изделий в текущий план", "ОК", "Назад", 1, false).ShowDialog();
                    }
                    break;
                case "-":
                    if (indexNameCmbProducts > 1)
                    {
                        ComboBox comboBox = new ComboBox();
                        TextBox textBox = new TextBox();
                        panelProducts.Children.Remove(massComboBoxs[indexNameCmbProducts - 1]);
                        panelCount.Children.Remove(massTextBoxs[indexNameCmbProducts - 1]);
                        massComboBoxs[indexNameCmbProducts - 1] = null;
                        massTextBoxs[indexNameCmbProducts - 1] = null;
                        indexNameCmbProducts--;
                    }
                    else
                    {
                        new CustomMessageBox("Внимание!", "Достигнут лимит в удалении сотрудников в текущий план", "ОК", "Назад", 1, false).ShowDialog();
                    }
                    break;
                default:
                    break;
            }
        }

        private void AddEmployee(object sender, RoutedEventArgs e)
        {
            Button pressedButton = new Button();
            pressedButton = (Button)sender;
            switch (pressedButton.Content)
            {
                case "+":
                    if (indexNameCmbEmployees < 10)
                    {
                        ComboBox comboBox = new ComboBox();
                        comboBox.Name = "cbNewEmployee" + indexNameCmbEmployees;
                        indexNameCmbEmployees++;
                        comboBox.DisplayMemberPath = "email";
                        comboBox.Margin = new Thickness(10, 5, 10, 0);
                        comboBox.ItemsSource = db.Employees.ToList();
                        comboBox.SelectedIndex = 0;
                        comboBox.Width = 120;
                        comboBox.Height = 25;
                        comboBox.Template = (ControlTemplate)comboBox.FindResource("CustomComboBoxTemplate");
                        massCmbEmployees[indexNameCmbEmployees - 1] = comboBox;
                        panelEmployees.Children.Add(comboBox);
                    }
                    else
                    {
                        new CustomMessageBox("Внимание!", "Достигнут лимит в добавлении сотрудников в текущий план", "ОК", "Назад", 1, false).ShowDialog();
                    }
                    break;
                case "-":
                    if (indexNameCmbEmployees > 1)
                    {
                        ComboBox comboBox = new ComboBox();
                        panelEmployees.Children.Remove(massCmbEmployees[indexNameCmbEmployees - 1]);
                        massCmbEmployees[indexNameCmbEmployees - 1] = null;
                        massTextBoxs[indexNameCmbEmployees - 1] = null;
                        indexNameCmbEmployees--;
                    }
                    else
                    {
                        new CustomMessageBox("Внимание!", "Достигнут лимит в удалении сотрудников в текущий план", "ОК", "Назад", 1, false).ShowDialog();
                    }
                    break;
                default:
                    break;
            }
        }

        private void tbCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (info.calculated is null)
            {
                chbCalculated.IsChecked = false;
            }
        }
    }
}
