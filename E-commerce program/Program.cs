using E_commerce_program.Models;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace E_commerce_program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queries queries = new Queries();
            ECommerceProgramContext context = new ECommerceProgramContext();

            

            while (true)
            {
                Console.Clear();

                Console.WriteLine("1. Hämta alla produkter i kategorin \"Electronics\" och sortera dem efter pris (högst först)");
                Console.WriteLine("2. Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter");
                Console.WriteLine("3. Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden");
                Console.WriteLine("4. Hitta de 3 mest sålda produkterna baserat på OrderDetail-data");
                Console.WriteLine("5. Lista alla kategorier och antalet produkter i varje kategori");
                Console.WriteLine("6. Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr\n");

                int choice = MenuOptionOnKeyPress();

                switch (choice)
                {
                    case 1: // Hämta alla produkter i kategorin "Electronics" och sortera dem efter pris (högst först)
                        Queries.GetProductsInCategory(context);
                        Console.ReadLine();
                        break;

                    case 2: // Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter
                        var suppliers =
                            from s in 
                                (from s in context.Suppliers
                                join p in context.Products on s.SupplierId equals p.SupplierId
                                where p.StockQuantity < 10
                                select s)
                            group s by s.SupplierId into g
                            select g.First();

                        foreach (Supplier supplier in suppliers)
                        {
                            Console.WriteLine(supplier.Name);
                        }

                        Console.ReadLine();
                        break;

                    case 3: // Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
                        DateTime monthEarlier = DateTime.Today.AddMonths(-1);
                        DateTime today = DateTime.Today;
                        var orderValue =
                            (from o in context.Orders
                             where o.OrderDate >= monthEarlier && o.OrderDate <= today
                             select o.TotalAmount).Sum();

                        Console.WriteLine("Totala ordervärdet: " + orderValue);
                        Console.ReadLine();
                        break;


                    case 4: // Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
                        var topProducts =
                            (from p in context.Products
                            join od in context.OrderDetails on p.ProductId equals od.ProductId
                            group od by p.ProductId into g
                            orderby g.Sum(item => item.Quantity) descending
                            select new
                            {
                                 Product = g.First().Product.Name,
                                 QuantitySold = g.Sum(item => item.Quantity)
                            }).Take(3);

                        foreach (var product in topProducts)
                        {
                            Console.WriteLine($"{product.Product} | Antal sålda: {product.QuantitySold}");
                        }

                        Console.ReadLine();
                        break;

                    case 5: // Lista alla kategorier och antalet produkter i varje kategori
                        var categoriesProductCount =
                            from p in context.Products
                            join c in context.Categories on p.CategoryId equals c.CategoryId
                            group p by c.CategoryId into g
                            select new
                            {
                                Category = g.First().Category.Name,
                                NumberOfProducts = g.Count()
                            };

                        foreach (var category in categoriesProductCount)
                        {
                            Console.WriteLine(category.Category + " | " + category.NumberOfProducts);
                        }

                        Console.ReadLine();
                        break;

                    case 6: // Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
                        var result =
                        from o in context.Orders
                        where o.TotalAmount > 1000
                        join c in context.Customers on o.CustomerId equals c.CustomerId
                        join od in context.OrderDetails on o.OrderId equals od.OrderId
                        join p in context.Products on od.ProductId equals p.ProductId
                        select new
                        {
                            o.OrderId,
                            o.OrderDate,
                            o.TotalAmount,
                            CustomerName = c.Name,
                            p.Name,
                            od.Quantity,
                            od.UnitPrice
                        };

                        var groups = result
                            .GroupBy(r => r.OrderId);

                        Console.WriteLine($"{"Order-ID", -9}  {"Datum", -11}  {"Kund", -21}  {"Totalvärde", -11}  {"Produktnamn", - 21}" +
                            $"  {"Kvantitet", -11}  {"Enhetspris"}");

                        foreach (var group in groups)
                        {
                            string formattedDate = group.First().OrderDate.ToString("yyyy-MM-dd");
                            Console.Write($"{group.Key, -8} | {formattedDate, -10} | {group.First().CustomerName,-20} |" +
                                $" {group.First().TotalAmount,-10} | ");

                            foreach (var item in group)
                            {
                                Console.SetCursorPosition(60, Console.CursorTop);
                                Console.WriteLine($"{ item.Name,-20} | { item.Quantity,-10} | { item.UnitPrice}");
                            }
                        }

                        Console.ReadLine();
                        break;

                    default:
                        System.Environment.Exit(0);
                        break;

                }
            }

            
                
        }

        public static int MenuOptionOnKeyPress()
        {
            ConsoleKey key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1)
                return 1;
            if (key == ConsoleKey.D2)
                return 2;
            if (key == ConsoleKey.D3)
                return 3;
            if (key == ConsoleKey.D4)
                return 4;
            if (key == ConsoleKey.D5)
                return 5;
            if (key == ConsoleKey.D6)
                return 6;
            else
                return 0;
        }
    }    
}
