using DiplomaProject.Pages.Employee;
using DiplomaProject.Pages.Material;
using DiplomaProject.Pages.Post;
using DiplomaProject.Pages.Product;
using DiplomaProject.Pages.ProductionPlan;
using DiplomaProject.Pages.ProductType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DiplomaProject.Classes
{
    internal class PageEvents
    {
        public static int pageState, addProductionPlanInfo = 10;
        public static Button previousButton;

        public void RefreshPage(Frame currentFrame)
        {
            Frame frame = currentFrame;
            if (frame.Content is PostPage)
            {
                frame.Navigate(new PostPage(frame));
            }
            if (frame.Content is EmployeePage)
            {
                frame.Navigate(new EmployeePage(frame));
            }
            if (frame.Content is ProductTypePage)
            {
                frame.Navigate(new ProductTypePage(frame));
            }
            if (frame.Content is MaterialPage)
            {
                frame.Navigate(new MaterialPage(frame));
            }
            if (frame.Content is ProductPage)
            {
                frame.Navigate(new ProductPage(frame));
            }
            if (frame.Content is ProductionPlanPage)
            {
                frame.Navigate(new ProductionPlanPage(frame));
            }
        }

        public void SetPressedButtonStyle(Button currentButton)
        {
            if (previousButton != currentButton)
            {
                currentButton.Style = (Style)currentButton.FindResource("ActiveNeutralButton");
                if (previousButton != null)
                {
                    previousButton.Style = (Style)previousButton.FindResource("NeutralButton");
                }
                previousButton = currentButton;
            }
        }
    }
}
