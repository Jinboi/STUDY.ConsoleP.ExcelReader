using Microsoft.EntityFrameworkCore;

namespace STUDY.ConsoleP.ExcelReader;
internal class YourDbContext : DbContext
{
    public DbSet<YourEntity> YourEntities { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\LocalDBDemo;Database=ExcelReader;Trusted_Connection=True;TrustServerCertificate=True;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<YourEntity>()
            .HasKey(e => e.Id);

        modelBuilder.Entity<YourEntity>()
            .Property(e => e.FirstName)
            .IsRequired();

        modelBuilder.Entity<YourEntity>()
            .Property(e => e.LastName)
            .IsRequired();
    }
    public class YourEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
