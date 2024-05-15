using Microsoft.EntityFrameworkCore;
using STUDY.ConsoleP.ExcelReader.Models;

namespace STUDY.ConsoleP.ExcelReader
{
    internal class YourDbContext : DbContext
    {
        public DbSet<ExcelDataModel> ExcelDataModels { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\LocalDBDemo;Database=ExcelReader;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }   
}
