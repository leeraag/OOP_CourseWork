using Lib_CourseWork;
using Microsoft.EntityFrameworkCore;


public class libraryContext : DbContext
{
    public DbSet<Reader> Readers => Set<Reader>();
    public DbSet<Book> Books => Set<Book>();
    //public libraryContext() => Database.EnsureCreated();
    static libraryContext() {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=library.db");
    }
}