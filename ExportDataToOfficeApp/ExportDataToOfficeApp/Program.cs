using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Create an alias to the Excel object model.
using Excel = Microsoft.Office.Interop.Excel;
namespace ExportDataToOfficeApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> carStocks = new List<Car>
            {
                new Car {Color="Green", Make="VW", PetName="Mary"},
                new Car {Color="Red", Make="Saab", PetName="Mel"},
                new Car {Color="Black", Make="Ford", PetName="Hank"},
                new Car {Color="Yellow", Make="BMW", PetName="Davie"}
            };
            ExportToExcel(carStocks);
            Console.ReadLine();
        }
        static void ExportToExcel(List<Car> carsInStock)
        {
            // Load up Excel, then make a new empty workbook.
            Excel.Application excelApp = new Excel.Application();
            // Go ahead and make Excel visible on the computer.
            excelApp.Visible = true;

            excelApp.Workbooks.Add();

            // This example uses a single workSheet.
            Excel._Worksheet worksheet = excelApp.ActiveSheet;
            // Establish column headings in cells.
            worksheet.Cells[1, "A"] = "Make";
            worksheet.Cells[1, "B"] = "Color";
            worksheet.Cells[1, "C"] = "PetName";

            int row = 1;
            foreach(Car c in carsInStock)
            {
                row++;
                worksheet.Cells[row, "A"] = "Make";
                worksheet.Cells[row, "B"] = "Color";
                worksheet.Cells[row, "c"] = "PetName";
            }
            // Give our table data a nice look and feel.
            worksheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);
            // Save the file, quit Excel, and display message to user.
            worksheet.SaveAs($@"{Environment.CurrentDirectory}\Inventory.xlsx");
            excelApp.Quit();
            Console.WriteLine("The Inventory.xslx file has been saved to your app folder");

        }
    }
}
