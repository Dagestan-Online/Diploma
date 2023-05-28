using DiplomaProject.Entities;
using DiplomaProject.Pages.Employee;
using DiplomaProject.Windows;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

namespace DiplomaProject.Pages.Product
{
    /// <summary>
    /// Логика взаимодействия для ProductPageInfo.xaml
    /// </summary>
    public partial class ProductPageInfo : Page
    {
        DiplomaDBEntities db;
        Frame masterFrame;
        string message = "";
        Entities.Product info;
        byte[] data;

        public ProductPageInfo(Frame frame, DiplomaDBEntities entities, Entities.Product product, string title)
        {
            InitializeComponent();
            tblTitle.Text = title;
            masterFrame = frame;
            DataContext = product;
            db = entities;
            cmbMaterial.ItemsSource = db.Materials.ToList();
            cmbProductType.ItemsSource = db.ProductTypes.ToList();
        }

        // метод проверки данных на корректность
        private bool CheckInfo()
        {
            info = this.DataContext as Entities.Product;
            if (data != null)
                info.image = data;
            if (info.name == null)
                message += "Наименование изделия не указано\n";
            if (!int.TryParse(tbCount.Text, out int result) || Convert.ToInt32(tbCount.Text) < 0)
                message += "Количество изделий должно быть целочисленным и положительным\n";
            if (info.Material == null)
                message += "Материал изделия не указан\n";
            if (info.ProductType == null)
                message += "Тип изделия не указан\n";
            if (info.description == null)
                tbDescription.Text = "Отсутствует";
            if (message == "")
                return true;
            else
                return false;
        }

        // сохранение данных
        private void BtnSaveInfo_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInfo()) //проверка на корректность данных
            {
                db.SaveChanges(); //сохранение данных
                new CustomMessageBox("Успех!", "Сохранение изделия прошло успешно!", "ОК", "Назад", 1, false).ShowDialog();
                CloseInfoAddPage_Click(sender, e); //закрытие страницы добавление данных
            }
            else
            {
                new CustomMessageBox("Внимание!", message, "ОК", "Назад", 3, false).ShowDialog();
                message = "";
            }
        }

        private void CloseInfoAddPage_Click(object sender, RoutedEventArgs e)
        {
            masterFrame.Navigate(new ProductPage(masterFrame));
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
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

        private void tbCount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
