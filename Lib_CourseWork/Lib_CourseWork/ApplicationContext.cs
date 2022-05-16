using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lib_CourseWork
{
    public class ApplicationContext : DbContext
    {
        //public DataSet dsReaders = new DataSet();
        //public string sqlReaders = "SELECT * FROM Readers";
        public DbSet<Reader> Readers => Set<Reader>();
        public DbSet<Book> Books => Set<Book>();
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=libs.db");
        }
    }
}
