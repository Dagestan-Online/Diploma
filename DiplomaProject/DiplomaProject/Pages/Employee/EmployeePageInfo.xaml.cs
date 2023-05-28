using DiplomaProject.Entities;
using DiplomaProject.Pages.Post;
using DiplomaProject.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Xml.Linq;
using static System.Net.WebRequestMethods;

namespace DiplomaProject.Pages.Employee
{
    /// <summary>
    /// Логика взаимодействия для EmployeePageInfo.xaml
    /// </summary>
    public partial class EmployeePageInfo : Page
    {
        DiplomaDBEntities db;
        Frame masterFrame;
        string message = "";
        Entities.Employee info;
        byte[] data;
        Regex regex = new Regex(@"\+\d{1}-\d{3}-\d{3}-\d{2}-\d{2}");

        public EmployeePageInfo(Frame frame, DiplomaDBEntities entities, Entities.Employee employee, string title)
        {
            InitializeComponent();
            tblTitle.Text = title;
            masterFrame = frame;
            DataContext = employee;
            db = entities;
            cmbPost.ItemsSource = db.Posts.ToList();
            //info = this.DataContext as Entities.Employee;
        }

        private bool CheckInfo()
        {
            info = this.DataContext as Entities.Employee;
            if (data != null)
                info.image = data;
            if (info.lastname == null)
                message += "Фамилия сотрудника не указана\n";
            if (info.name == null)
                message += "Имя сотрудника не указано\n";
            if (info.middlename == null)
                message += "Отчество сотрудника не указано\n";
            if (info.Post == null)
                message += "Должность не указана\n";
            if (info.phone == null)
            {
                message += "Номер телефона не указан\n";
            }
            else
            {
                if (!regex.IsMatch(tbPhone.Text))
                    message += "Номер телефона не соответствует шаблону\n";
                if (tbPhone.Text.Length < 16)
                    message += "Номер телефона указан неполностью\n";
            }
            if (info.email == null)
            {
                message += "Электронная почта не указана\n";
            }
            else
            {
                if (!new EmailAddressAttribute().IsValid(tbEmail.Text))
                    message += "Электронная почта недействительна\n";
            }
            if (info.birthDate == null)
                message += "Дата рождения не указана\n";
            if (info.employmentDate == null)
                message += "Дата трудоустройства не указана\n";
            if (dpBirth.SelectedDate > dpEmployment.SelectedDate)
                message += "Дата рождения не может быть больше даты трудоустройства\n";
            if (dpBirth.SelectedDate != null && dpEmployment.SelectedDate != null)
            {
                var ageInYears = GetDifferenceInYears(dpBirth.SelectedDate.Value, DateTime.Today);
                if (ageInYears < 18)
                {
                    message += "Новый сотрудник несовершеннолетний\n";
                }
            }
            using (Entities.DiplomaDBEntities context = new DiplomaDBEntities())
            {
                //Entities.Employee[] currentEmployee = context.Employees.ToArray();
                Entities.Employee currentEmail = context.Employees.Where(b => b.email == tbEmail.Text).FirstOrDefault();
                if (currentEmail != null)
                {
                    message += "Такая электронная почта уже существует\n";
                }
            }
                if (message == "")
                return true;
            else
                return false;
        }

        private int GetDifferenceInYears(DateTime startDate, DateTime endDate)
        {
            return (endDate.Year - startDate.Year - 1) +
                (((endDate.Month > startDate.Month) ||
                ((endDate.Month == startDate.Month) && (endDate.Day >= startDate.Day))) ? 1 : 0);
        }

        private void BtnSaveInfo_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInfo())
            {
                db.SaveChanges();
                new CustomMessageBox("Успех!", "Сохранение сотрудника прошло успешно!", "ОК", "Отменить", 1, false).ShowDialog();
                CloseInfoAddPage_Click(sender, e);
            }
            else
            {
                new CustomMessageBox("Внимание!", message, "ОК", "Отменить", 3, false).ShowDialog();
                message = "";
            }
        }

        private void CloseInfoAddPage_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Navigate(new EmployeePage(masterFrame));
        }

        private void ChooseImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Изображения (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg";
            if (fileDialog.ShowDialog() == true)
            {
                string file = fileDialog.FileName;
                try
                {
                    data = System.IO.File.ReadAllBytes(file);
                    img.Source = new BitmapImage(new Uri(file));
                }
                catch (Exception ex)
                {
                    new CustomMessageBox("Предупреждение!", ex.Message, "ОК", "Нет", 3, false).ShowDialog();
                }
            }
        }

        private void tbPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
            if (tbPhone.Text.Length == 6)
            {
                tbPhone.Text += "-";
                tbPhone.CaretIndex = tbPhone.Text.Length;
            }
            if (tbPhone.Text.Length == 10)
            {
                tbPhone.Text += "-";
                tbPhone.CaretIndex = tbPhone.Text.Length;
            }
            if (tbPhone.Text.Length == 13)
            {
                tbPhone.Text += "-";
                tbPhone.CaretIndex = tbPhone.Text.Length;
            }
            if (tbPhone.Text.Length < 3)
            {
                tbPhone.Text = "+7-";
                tbPhone.CaretIndex = tbPhone.Text.Length;
            }
        }

        private void tbPhone_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbPhone.Text == "")
            {
                tbPhone.Text = "+7-";
            }
            tbPhone.CaretIndex = tbPhone.Text.Length;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (dpEmployment.SelectedDate is null)
            {
                dpEmployment.SelectedDate = DateTime.Today;
            }
            if (img.Source is null)
            {
                var uri = new Uri("pack://application:,,,/Images/picture.png");
                img.Source = new BitmapImage(uri);
                var bitmap = new BitmapImage(uri);
                var buffer = GetImageBuffer(bitmap, new PngBitmapEncoder());
                data = buffer;
            }
        }

        public byte[] GetImageBuffer(BitmapSource bitmap, BitmapEncoder encoder)
        {
            encoder.Frames.Add(BitmapFrame.Create(bitmap));

            using (var stream = new MemoryStream())
            {
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
    }
}
