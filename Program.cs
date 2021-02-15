using static System.Console; // aby nie pisać Console.WriteLine() tylko WriteLine()
using NorthwindEFCore.Model; // model bazy
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace NorthwindEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            CategoriesAndProducts();
        }

        static void CategoriesAndProducts()
        {
            using var db = new Northwind(); //C#8

            WriteLine("Lista kategorii i liczba produktów:");
            // kwerenda pobiera wszystkie kategorie i powiązane z nimi produkty 
            IQueryable<Category> categories = db.Categories
                .Include(c => c.Products);

            int i = 1;
            foreach (var c in categories)
            {
                WriteLine($"{i:D2}. {c.CategoryName}: {c.Products.Count}");
                i++;
            }

            //automatyczne zwolnienie zasobów dla zmiennej  db            
        }
    }
}