using Microsoft.EntityFrameworkCore;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace NorthwindEFCore.Model
{
    // klasa odpowiedzialna za zarządzanie połączeniem z bazą danych
    public class Northwind : DbContext
    {
        // properties mapujace na tabele w bazie danych 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        // konfiguracja connection string
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            path = Path.Combine(path, "Northwind.db");
            optionsBuilder.UseSqlite($"Filename={path}");
            //poprawione
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // przykład użycia Fluent API zamiast atrybutów (adnotacji)
            // do ograniczenia długości nazwy kategorii do 15 znaków
            modelBuilder.Entity<Category>()
            .Property(category => category.CategoryName)
            .IsRequired() // ponieważ NOT NULL
            .HasMaxLength(15);

            // dodane, aby skorygować działania na decima w SQLite
            modelBuilder.Entity<Product>()
            .Property(product => product.Cost)
            .HasConversion<double>();
        }
    }
}