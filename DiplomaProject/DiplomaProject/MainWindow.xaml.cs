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
using DiplomaProject.Classes;
using DiplomaProject.Pages.Employee;
using DiplomaProject.Pages.ProductType;
using DiplomaProject.Pages.Material;
using DiplomaProject.Pages.Product;
using DiplomaProject.Pages.ProductionPlan;
using System.Runtime.Remoting.Contexts;

namespace DiplomaProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frPages.Navigate(new ProductPage(frPages));
            PageEvents.previousButton = btnPoduct;
        }

        private void NavigatePage_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btnPost":
                    frPages.Navigate(new PostPage(frPages));
                    break;
                case "btnEmployee":
                    frPages.Navigate(new EmployeePage(frPages));
                    break;
                case "btnPoductionPlan":
                    frPages.Navigate(new ProductionPlanPage(frPages));
                    break;
                case "btnPoduct":
                    frPages.Navigate(new ProductPage(frPages));
                    break;
                case "btnProductType":
                    frPages.Navigate(new ProductTypePage(frPages));
                    break;
                case "btnMaterial":
                    frPages.Navigate(new MaterialPage(frPages));
                    break;
                default:
                    break;
            }
            //btn.Style = (Style)btn.FindResource("ActiveNeutralButton");
            PageEvents events = new PageEvents();
            events.SetPressedButtonStyle(btn);
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                PageEvents.pageState = 2;
                //PageEvents.addProductionPlanInfo = 20;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                PageEvents.pageState = 0;
                //PageEvents.addProductionPlanInfo = 10;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                PageEvents.pageState = 1;
                //PageEvents.addProductionPlanInfo = 10;
            }
            PageEvents currentPage = new PageEvents();
            currentPage.RefreshPage(frPages);
        }

        private void CloseProgram_Click(object sender, RoutedEventArgs e)
        {
            new CustomMessageBox("Вы уверены?", "Вы точно хотите закрыть программу?", "Да", "Нет", 2, true).ShowDialog();
            if (ListEvents.incidentResult is true)
            {
                Close();
            }
        }
    }
}
