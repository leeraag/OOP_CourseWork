using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Lib_CourseWork
{
    public partial class libraryContext : DbContext
    {
        public libraryContext()
        {
        }

        public libraryContext(DbContextOptions<libraryContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<Reader> Readers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source= C:\\Users\\valer\\OneDrive\\Документы\\Учеба\\2 курс\\2 семестр\\ооп\\курсач\\Lib_CourseWork\\Lib_CourseWork\\bin\\Debug\\net6.0-windows\\library.db");
                // optionsBuilder.UseSqlite("Data Source= C:\\Users\\valer\\OneDrive\\Документы\\Учеба\\2 курс\\2 семестр\\ооп\\курсач\\Lib_CourseWork\\Lib_CourseWork\\bin\\Release\\net6.0-windows\\library.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.BookId, "IX_Books_BookId")
                    .IsUnique();
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.HasIndex(e => e.ReaderId, "IX_Readers_ReaderId")
                    .IsUnique();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
