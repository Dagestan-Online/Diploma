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
using System.Windows.Controls;

namespace DiplomaProject.Classes
{
    internal class ListEvents
    {
        public static bool incidentResult;
        public static string currentList;

        public int SetListContentSize(int size)
        {
            
            if (PageEvents.pageState == 2)
            {
                switch (currentList)
                {
                    case "PostPage":
                        return size = 11;
                        break;
                    case "ProductTypePage":
                        return size = 11;
                        break;
                    case "MaterialPage":
                        return size = 11;
                        break;
                    case "EmployeePage":
                        return size = 5;
                        break;
                    case "ProductionPlanPage":
                        return size = 4;
                        break;
                    case "ProductPage":
                        return size = 4;
                        break;
                    default:
                        return size = 12;
                        break;
                }
                /*if (frame.Content is PostPage)
                {
                    return size = 11;
                }
                if (frame.Content is ProductTypePage)
                {
                    return size = 11;
                }
                if (frame.Content is MaterialPage)
                {
                    return size = 11;
                }
                if (frame.Content is EmployeePage)
                {
                    return size = 6;
                }
                if (frame.Content is ProductionPlanPage)
                {
                    return size = 6;
                }
                if (frame.Content is ProductPage)
                {
                    return size = 4;
                }
                else
                {
                    return size = 12;
                }*/
            }
            else
            {
                switch (currentList)
                {
                    case "PostPage":
                        return size = 6;
                        break;
                    case "ProductTypePage":
                        return size = 6;
                        break;
                    case "MaterialPage":
                        return size = 6;
                        break;
                    case "EmployeePage":
                        return size = 2;
                        break;
                    case "ProductionPlanPage":
                        return size = 2;
                        break;
                    case "ProductPage":
                        return size = 2;
                        break;
                    default:
                        return size = 6;
                        break;
                }
                /*if (frame.Content is PostPage)
                {
                    return size = 6;
                }
                if (frame.Content is ProductTypePage)
                {
                    return size = 6;
                }
                if (frame.Content is MaterialPage)
                {
                    return size = 6;
                }
                if (frame.Content is EmployeePage)
                {
                    return size = 3;
                }
                if (frame.Content is ProductionPlanPage)
                {
                    return size = 3;
                }
                if (frame.Content is ProductPage)
                {
                    return size = 2;
                }
                else
                {
                    return size = 6;
                }*/
            }
        }
    }
}
