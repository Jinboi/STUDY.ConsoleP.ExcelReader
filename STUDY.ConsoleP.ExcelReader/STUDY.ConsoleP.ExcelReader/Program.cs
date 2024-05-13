namespace STUDY.ConsoleP.ExcelReader;
public class Program
{
    static void Main(string[] args)
    {
        {
            var workingDirectory = Directory.GetCurrentDirectory();
            var excelFileName = "ExcelReaderData.xlsx"; 
            var excelFilePath = Path.Combine(workingDirectory, excelFileName);

            var data = ExcelReader.ReadFromExcel(excelFilePath);

            DbPopulator.PopulateDatabase(data);

            Console.WriteLine("Data has been read0 from Excel and populated into the database.");
            Console.ReadLine();
        }
    }
}
