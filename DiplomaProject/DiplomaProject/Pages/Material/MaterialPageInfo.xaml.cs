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

namespace DiplomaProject.Pages.Material
{
    /// <summary>
    /// Логика взаимодействия для MaterialPageInfo.xaml
    /// </summary>
    public partial class MaterialPageInfo : Page
    {
        DiplomaDBEntities db;
        Frame masterFrame;
        string message = "";

        public MaterialPageInfo(Frame frame, DiplomaDBEntities entities, Entities.Material material, string title)
        {
            InitializeComponent();
            tblTitle.Text = title;
            masterFrame = frame;
            DataContext = material;
            db = entities;
        }

        private bool CheckInfo()
        {
            var info = this.DataContext as Entities.Material;
            if (info.name == null || tbName.Text == "")
                message += "Наименование материала не указано\n";
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
                new CustomMessageBox("Успех!", "Сохранение материала прошло успешно!", "ОК", "Отменить", 1, false).ShowDialog();
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
            masterFrame.Navigate(new MaterialPage(masterFrame));
        }
    }
}
