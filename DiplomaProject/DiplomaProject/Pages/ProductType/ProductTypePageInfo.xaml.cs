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

namespace DiplomaProject.Pages.ProductType
{
    /// <summary>
    /// Логика взаимодействия для ProductTypePageInfo.xaml
    /// </summary>
    public partial class ProductTypePageInfo : Page
    {
        DiplomaDBEntities db;
        Frame masterFrame;
        string message = "";

        public ProductTypePageInfo(Frame frame, DiplomaDBEntities entities, Entities.ProductType productType, string title)
        {
            InitializeComponent();
            tblTitle.Text = title;
            masterFrame = frame;
            DataContext = productType;
            db = entities;
        }

        private bool CheckInfo()
        {
            var info = this.DataContext as Entities.ProductType;
            if (info.name == null || tbName.Text == "")
                message += "Наименование типа изделия не указано\n";
            if (message == "")
                return true;
            else
                return false;
        }

        private void BtnSaveInfo_Click(object sender, RoutedEventArgs e)
        {
            if (CheckInfo())
            {
                db.SaveChanges();
                new CustomMessageBox("Успех!", "Сохранение типа изделия прошло успешно!", "ОК", "Отменить", 1, false).ShowDialog();
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
            masterFrame.Navigate(new ProductTypePage(masterFrame));
        }
    }
}
