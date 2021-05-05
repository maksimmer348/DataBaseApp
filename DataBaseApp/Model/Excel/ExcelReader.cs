using System;
using System.IO;
using System.Windows;
using OfficeOpenXml;
using Prism.Mvvm;

namespace DataBaseApp.Model.Excel
{
    public class ExcelReader : BindableBase
    {
        private ExcelReport exRep;
        public ExcelReader()
        {
           
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        }

        private void Report()
        {
            var reporter = new ExcelReporter().GetReport();
            var crtTable = new CreateExcelTable().Generate(reporter);

            File.WriteAllBytes("Report.xlsx", crtTable);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Report();
        }
    }

    public class ExcelReport
    {
        public OwerLoad Load;
        public OwerLoadSpecifications[] OwerSpecifications;
    }

    public class ExcelReporter
    {

        public ExcelReport GetReport()
        {
            return new ExcelReport
            {
                Load = new OwerLoad
                {

                    Name = "OwerLoad ZZ",
                    Height = 50.14
                },
                OwerSpecifications = new[]
                {
                    new OwerLoadSpecifications
                        {SerialNumber = "FGGF20", Power = 50.1, Date = new DateTime(2021, 10, 2)},
                    new OwerLoadSpecifications {SerialNumber = "FGGF20", Power = 50.1, Date = new DateTime(2021, 10, 2)}
                }
            };
        }
    }

    public class OwerLoad
    {
        public string Name { get; set; }
        public double Height { get; set; }
    }

    public class OwerLoadSpecifications
    {
        public string SerialNumber;
        public Double Power { get; set; }
        public DateTime Date { get; set; }
    }

    public class CreateExcelTable
    {
        public byte[] Generate(ExcelReport report)
        {
            var pack = new ExcelPackage();
            var sheet = pack.Workbook.Worksheets.Add("Load Report");
            sheet.Cells["B2"].Value = "Load:";
            sheet.Cells[2, 3].Value = report.Load.Name;
            sheet.Cells["B3"].Value = "Other:";
            sheet.Cells["C3"].Value = $"{report.Load.Height}";
            pack.Workbook.Protection.LockStructure = true;
            pack.Workbook.Protection.SetPassword("password");
            return pack.GetAsByteArray();
        }
    }
}