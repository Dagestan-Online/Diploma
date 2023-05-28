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
using DiplomaProject.Entities;
using DiplomaProject.Windows;

namespace DiplomaProject.Pages.Post
{
    /// <summary>
    /// Логика взаимодействия для PostPageInfo.xaml
    /// </summary>
    public partial class PostPageInfo : Page
    {
        DiplomaDBEntities db;
        Frame masterFrame;
        string message = "";

        public PostPageInfo(Frame frame, DiplomaDBEntities entities, Entities.Post post, string title)
        {
            InitializeComponent();
            tblTitle.Text = title;
            masterFrame = frame;
            DataContext = post;
            db = entities;
        }

        private bool CheckInfo()
        {
            var info = this.DataContext as Entities.Post;
            if (info.name == null)
                message += "Наименование должности не указано\n";
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
                new CustomMessageBox("Успех!", "Сохранение должности прошло успешно!", "ОК", "Отменить", 1, false).ShowDialog();
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
            masterFrame.Navigate(new PostPage(masterFrame));
        }
    }
}
