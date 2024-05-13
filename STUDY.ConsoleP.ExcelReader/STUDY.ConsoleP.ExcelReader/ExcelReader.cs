using OfficeOpenXml;
using static STUDY.ConsoleP.ExcelReader.YourDbContext;

namespace STUDY.ConsoleP.ExcelReader;
internal class ExcelReader
{
    public static List<YourEntity> ReadFromExcel(string excelFilePath)
        {
            var result = new List<YourEntity>();

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Set license context

            using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
            {               
                var worksheet = package.Workbook.Worksheets[0];                 
            }
            return result;
        }
}
