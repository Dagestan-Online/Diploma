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
using System.Reflection;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;
using DiplomaProject.Entities;
using System.Globalization;

namespace DiplomaProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ListEvents.currentList = "ProductPage";
            frPages.Navigate(new ProductPage(frPages));
            PageEvents.previousButton = btnPoduct;
        }

        private void NavigatePage_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Name)
            {
                case "btnPost":
                    ListEvents.currentList = "PostPage";
                    frPages.Navigate(new PostPage(frPages));
                    break;
                case "btnEmployee":
                    ListEvents.currentList = "EmployeePage";
                    frPages.Navigate(new EmployeePage(frPages));
                    break;
                case "btnPoductionPlan":
                    ListEvents.currentList = "ProductionPlanPage";
                    frPages.Navigate(new ProductionPlanPage(frPages));
                    break;
                case "btnPoduct":
                    ListEvents.currentList = "ProductPage";
                    frPages.Navigate(new ProductPage(frPages));
                    break;
                case "btnProductType":
                    ListEvents.currentList = "ProductTypePage";
                    frPages.Navigate(new ProductTypePage(frPages));
                    break;
                case "btnMaterial":
                    ListEvents.currentList = "MaterialPage";
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

        private void CreateReport(object sender, RoutedEventArgs e)
        {
            //Random random = new Random();
            //string NumDoc = random.Next(1, 1000).ToString();
            //string currentDate = DateTime.Today.Month.ToString();
            Entities.DiplomaDBEntities db = new DiplomaDBEntities();
            long totalCountProducts = 0;

            //string mymonth = DateTime.Now.ToString("MMM", CultureInfo.CurrentCulture);

            var application = new Microsoft.Office.Interop.Word.Application();

            Microsoft.Office.Interop.Word.Document document = application.Documents.Add();

            document.PageSetup.BottomMargin = 5;
            document.PageSetup.TopMargin = 5;
            document.PageSetup.LeftMargin = 50;
            document.PageSetup.RightMargin = 50;

            Microsoft.Office.Interop.Word.Paragraph DocNum = document.Paragraphs.Add();
            Microsoft.Office.Interop.Word.Range DocRange = DocNum.Range;

            DocRange.Text = $"Отчет от {DateTime.Now.ToShortDateString()}";

            DocNum.set_Style("Заголовок 1");
            DocNum.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            DocRange.Font.Color = Word.WdColor.wdColorBlack;
            DocRange.Font.Size = 16;
            DocRange.Font.Bold = 1;
            DocRange.InsertParagraphAfter();

            Microsoft.Office.Interop.Word.Paragraph DocDescription = document.Paragraphs.Add();
            Microsoft.Office.Interop.Word.Range DocDescriptionRange = DocDescription.Range;

            Microsoft.Office.Interop.Word.Paragraph tableParagraph = document.Paragraphs.Add();
            Microsoft.Office.Interop.Word.Range tableRange = tableParagraph.Range;
            Microsoft.Office.Interop.Word.Table Information = document.Tables.Add(tableRange, 8, 2);

            //Information.Range.Cells.HeightRule = WdRowHeightRule.wdRowHeightAtLeast;
            Information.Range.Cells.VerticalAlignment = Microsoft.Office.Interop.Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            Information.Borders.Enable = 1;

            Microsoft.Office.Interop.Word.Range cellRange;

            cellRange = Information.Cell(1, 1).Range;
            cellRange.Text = "Наименование";
            cellRange.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            cellRange.Underline = Word.WdUnderline.wdUnderlineSingle;
            cellRange.Font.Size = 12;
            cellRange.Font.Bold = 1;
            cellRange.Font.Color = Word.WdColor.wdColorBlack;
            cellRange = Information.Cell(2, 1).Range;
            cellRange.Text = "Всего создано планов";
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(3, 1).Range;
            cellRange.Text = "Всего выполненных планов";
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(4, 1).Range;
            cellRange.Text = "Всего текущих планов";
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(5, 1).Range;
            cellRange.Text = "Всего не начавшихся планов";
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(6, 1).Range;
            cellRange.Text = "Всего подсчитанных планов";
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(7, 1).Range;
            cellRange.Text = "Всего не подсчитанных планов";
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(8, 1).Range;
            cellRange.Text = "Всего имеющихся товаров";
            cellRange.Font.Size = 12;

            cellRange = Information.Cell(1, 2).Range;
            cellRange.Text = "Количество";
            cellRange.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            cellRange.Underline = Word.WdUnderline.wdUnderlineSingle;
            cellRange.Font.Size = 12;
            cellRange.Font.Bold = 1;
            cellRange.Font.Color = Word.WdColor.wdColorBlack;
            cellRange = Information.Cell(2, 2).Range;
            cellRange.Text = db.ProductionPlans.Count().ToString();
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(3, 2).Range;
            Entities.ProductionPlan[] completePlans = db.ProductionPlans.Where(x => x.finishDate <= DateTime.Today).ToArray();
            cellRange.Text = completePlans.Length.ToString();
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(4, 2).Range;
            Entities.ProductionPlan[] currentPlans = db.ProductionPlans.Where(x => x.startDate < DateTime.Today && x.finishDate > DateTime.Today).ToArray();
            cellRange.Text = currentPlans.Length.ToString();
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(5, 2).Range;
            Entities.ProductionPlan[] notStartedPlans = db.ProductionPlans.Where(x => x.startDate > DateTime.Today).ToArray();
            cellRange.Text = notStartedPlans.Length.ToString();
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(6, 2).Range;
            Entities.ProductionPlan[] calculatedPlans = db.ProductionPlans.Where(x => x.calculated == true).ToArray();
            cellRange.Text = calculatedPlans.Length.ToString();
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(7, 2).Range;
            Entities.ProductionPlan[] notCalculatedPlans = db.ProductionPlans.Where(x => x.calculated == false).ToArray();
            cellRange.Text = notCalculatedPlans.Length.ToString();
            cellRange.Font.Size = 12;
            cellRange = Information.Cell(8, 2).Range;
            Entities.Product[] totalProducts = db.Products.ToArray();
            for (int i = 1; i < totalProducts.Length; i++)
            {
                totalCountProducts += (long)Math.Ceiling((decimal)totalProducts[i].count); //Convert.ToInt64(totalProducts[i].count);
            }
            cellRange.Text = $"{totalCountProducts} шт.";
            cellRange.Font.Size = 12;

            //Сохранение документа
            object filename = $@"Отчет от {DateTime.Now.ToShortDateString()}.docx";
            object filename1 = $@"Отчет от {DateTime.Now.ToShortDateString()}.pdf";
            try
            {
                document.SaveAs(filename);
                document.SaveAs(filename1, Microsoft.Office.Interop.Word.WdExportFormat.wdExportFormatPDF);
            }
            catch (Exception ex)
            {
                new CustomMessageBox("Внимание!", ex.Message, "ОК", "Отменить", 3, false).ShowDialog();
            }
            try
            {
                //Закрытие текущего документа
                document.Close();
            }
            catch (Exception ex)
            {
                new CustomMessageBox("Внимание!", ex.Message, "ОК", "Отменить", 3, false).ShowDialog();
            }
            document = null;
            //Закрытие приложения Word
            application.Quit();
            application = null;
            new CustomMessageBox("Успех", $"Создание отчета от {DateTime.Now.ToShortDateString()} прошло успешно!", "ОК", "Отменить", 1, false).ShowDialog();
        }
    }
}
