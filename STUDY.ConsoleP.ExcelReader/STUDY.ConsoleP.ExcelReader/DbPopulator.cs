using static STUDY.ConsoleP.ExcelReader.YourDbContext;

namespace STUDY.ConsoleP.ExcelReader;
internal class DbPopulator
{
    public static void PopulateDatabase(List<YourEntity> data)
    {
        using (var dbContext = new YourDbContext())
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            dbContext.YourEntities.AddRange(data);
            dbContext.SaveChanges();
        }
    }
}
