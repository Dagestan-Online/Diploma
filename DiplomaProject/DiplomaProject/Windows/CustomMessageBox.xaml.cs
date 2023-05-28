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
using System.Windows.Shapes;
using System.Media;
using System.Windows.Interop;
using System.Drawing;
using DiplomaProject.Classes;
using static System.Net.Mime.MediaTypeNames;

namespace DiplomaProject.Windows
{
    /// <summary>
    /// Логика взаимодействия для CustomMessageBox.xaml
    /// </summary>
    public partial class CustomMessageBox : Window
    {
        public CustomMessageBox(string title, string content, string posiriveButtonContent, string negativeButtonContent, int imageNumber, bool visibilityButton)
        {
            SystemSounds.Exclamation.Play();
            InitializeComponent();
            CheckVisibilityButton(visibilityButton);
            btnYes.Content = posiriveButtonContent;
            btnNo.Content = negativeButtonContent;
            tblTitle.Text = title;
            tblContent.Text = content;
            SetImage(imageNumber);
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void IncidentResult_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btnNo":
                    ListEvents.incidentResult = false;
                    Close();
                    break;
                case "btnYes":
                    ListEvents.incidentResult = true;
                    Close();
                    break;
                default:
                    
                    break;
            }
        }

        private void CheckVisibilityButton(bool flag)
        {
            if (!flag)
            {
                btnNo.Visibility = Visibility.Hidden;
            }
            else
            {
                btnNo.Visibility = Visibility.Visible;
            }
        }

        private void SetImage(int number)
        {
            switch (number)
            {
                case 1:
                    imgBox.Source = Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Information.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case 2:
                    imgBox.Source = Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Question.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case 3:
                    imgBox.Source = Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Warning.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
                case 4:
                    imgBox.Source = Imaging.CreateBitmapSourceFromHIcon(SystemIcons.Error.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
                    break;
            }
        }
    }
}
