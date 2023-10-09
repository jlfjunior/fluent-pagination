using Microsoft.EntityFrameworkCore;

namespace FluentPagination.Tests.Data;

public class Context : DbContext
{
    public DbSet<Person> People { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=LocalDatabase.db");
    }
}