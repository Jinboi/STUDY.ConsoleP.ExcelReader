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

                // Start iterating from the second row (assuming the first row contains column headers)
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    // Create a new YourEntity instance for each row
                    var entity = new YourEntity();

                    // Set ID from column A (index 1)
                    entity.Id = worksheet.Cells[row, 1].GetValue<int>();

                    // Set FirstName from column B (index 2)
                    entity.FirstName = worksheet.Cells[row, 2].GetValue<string>();

                    // Set LastName from column C (index 3)
                    entity.LastName = worksheet.Cells[row, 3].GetValue<string>();

                    // Add the populated entity to the result list
                    result.Add(entity);
                }

        }
            return result;
        }
}
