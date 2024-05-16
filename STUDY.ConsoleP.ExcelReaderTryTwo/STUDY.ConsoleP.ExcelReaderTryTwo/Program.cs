using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using STUDY.ConsoleP.ExcelReaderTryTwo;

ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

CreateDatabase();

Console.WriteLine("Press Any Key To Continue");
Console.ReadLine();

var excelData = LoadExcelData();

UpdateDatabase(excelData);

Console.WriteLine("Data added to the database.");
Console.WriteLine("Press Any Key To Exit");

Console.ReadLine();
void CreateDatabase()
{
    using (var context = new ExcelDbContext())
    {
        if (!context.Database.CanConnect())
        {
            context.Database.Migrate();
            Console.WriteLine("Database migration complete.");
        }
        else
        {
            Console.WriteLine("Database already exists.");
        }
    }
}
List<ExcelDbModel> LoadExcelData()
{
    string fileName = "ExcelReaderData.xlsx";
    string filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);
    ExcelDataReader reader = new ExcelDataReader();

    return reader.ReadExcelFile(filePath);
}
void UpdateDatabase(List<ExcelDbModel> excelData)
{
    using (var context = new ExcelDbContext())
    {
        context.ExcelDataModels.AddRange(excelData);
        context.SaveChanges();
    }
}
