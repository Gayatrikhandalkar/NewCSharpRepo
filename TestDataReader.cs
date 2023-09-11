using iTextSharp.text.pdf.parser;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using SeleniumTestProject.Models;
using System.Text;
using Path = System.IO.Path;
using NUnit.Framework.Internal.Execution;
using SeleniumTestProject.PageObject.ManageViewing;
using System.Data;
using ExcelDataReader;
using IronXL;
using OfficeOpenXml;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;
using Spire.Xls;

namespace SeleniumTestProject.Utilities
{
    public class TestDataReader
    {
        

        protected TestDataReader()
        {
            //Removing warning by adding a protected constructor
        }

        public static string GetProjectRootDirectory()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return currentDirectory.Split("bin")[0];
        }
        public static TestDataStructures GetTestDataJsonObject(String country)
        {
            string path = Path.Combine(GetProjectRootDirectory(), "TestData", country + "_Clarity_TestData.json");
            var jObject = File.ReadAllText(path);
            var jsonObj = JsonConvert.DeserializeObject<TestDataStructures>(jObject);
            return jsonObj;
        }


        public static string Decoding(string pass)
        {
            var valueBytes = System.Convert.FromBase64String(pass);
            return UTF8Encoding.UTF8.GetString(valueBytes);
        }
        public static string DocumentPath()
        {
            string path = Path.Combine(GetProjectRootDirectory(), "Documents\\Upload");
            return path;
        }
        public static string DownloadFilePath()
        {
            string path = Path.Combine(GetProjectRootDirectory(), "Documents\\DownloadedDocument");
            return path;
        }
        public static bool PdfRead(string pdfName, string TEXT)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            currentDirectory = currentDirectory.Split("Source")[0];
            currentDirectory = currentDirectory + "Downloads\\" + pdfName + ".pdf";
            PdfReader reader = new PdfReader(currentDirectory);
            string pdfText = PdfTextExtractor.GetTextFromPage(reader, 1).Trim();
            reader.Close();
            if (pdfText.Contains(TEXT))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ExcelFormatConverterFromXlsToXlsx(string reportname)
        {            
            Workbook workbook = new Workbook();
            workbook.LoadFromFile(GetProjectRootDirectory() + "\\Documents\\Download\\" + reportname + "_" + CLDate.GenerateTodayDateWithFormat("dd-MM-yyyy") + ".xls");
            workbook.SaveToFile(GetProjectRootDirectory() + "\\Documents\\Download\\" + reportname + "_" + CLDate.GenerateTodayDateWithFormat("dd-MM-yyyy") + "_New.xlsx", ExcelVersion.Version2016);
            FileInfo fileInfo = new FileInfo(GetProjectRootDirectory() + "\\Documents\\Download\\" + reportname + "_" + CLDate.GenerateTodayDateWithFormat("dd-MM-yyyy") + ".xls");
            fileInfo.Delete();
        }

        public static List<string> ExtractExcelData(string reportname, int targetedColumnCount, int rowNumberToStartCounting)
        {
            FileInfo fileInfo = new FileInfo(GetProjectRootDirectory() + "\\Documents\\Download\\" + reportname + "_" + CLDate.GenerateTodayDateWithFormat("dd-MM-yyyy") + "_New.xlsx");
            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
            int RowCount = worksheet.Dimension.End.Row;
            Console.WriteLine("Row count from Excelsheet is " + (RowCount - 1));
            string combinedStringOfExcelValuesRowWise = "";
            List<string> recordsFromExcel = new List<string>();
            for (int i = rowNumberToStartCounting; i <= RowCount; i++)
            {
                for (int j = 1; j <= targetedColumnCount; j++)
                {
                    String data = worksheet.Cells[i, j].Value.ToString();
                    combinedStringOfExcelValuesRowWise = combinedStringOfExcelValuesRowWise + data;
                }
                recordsFromExcel.Add(Regex.Replace(combinedStringOfExcelValuesRowWise, @"\s+", ""));
                TestContext.Progress.WriteLine(Regex.Replace(combinedStringOfExcelValuesRowWise, @"\s+", ""));
                combinedStringOfExcelValuesRowWise = "";
            }
            TestContext.Progress.WriteLine(recordsFromExcel.Count);
            fileInfo.Delete();
            return recordsFromExcel;
        }

        public static void DeleteFile(string filepath)
        {
            FileInfo fileInfo = new FileInfo(filepath);
            fileInfo.Delete();
        }
    }
}
