using E_commerce_program.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce_program
{
    internal class Queries
    {
        public static void GetProductsInCategory(ECommerceProgramContext context)
        {
            var products =
                        from p in context.Products
                        join c in context.Categories on p.CategoryId equals c.CategoryId
                        where c.Name == "Electronics"
                        orderby p.Price descending
                        select p;

            foreach (Product product in products)
            {
                Console.WriteLine(product.Name + " | " + product.Price);
            }
        }

        public static void ListSuppliers(ECommerceProgramContext context)
        {
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
        }

        public static void CalculateOrderValue(ECommerceProgramContext context)
        {
            DateTime monthEarlier = DateTime.Today.AddMonths(-1);
            DateTime today = DateTime.Today;
            var orderValue =
                (from o in context.Orders
                 where o.OrderDate >= monthEarlier && o.OrderDate <= today
                 select o.TotalAmount).Sum();

            Console.WriteLine("Totala ordervärdet: " + orderValue);
            Console.ReadLine();
        }

        public static void FindMostSoldProducts(ECommerceProgramContext context)
        {
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
        }

        public static void CategoriesContainedProducts(ECommerceProgramContext context)
        {
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
        }

        public static void GetOrderAndCustomerData(ECommerceProgramContext context)
        {
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

            Console.WriteLine($"{"Order-ID",-9}  {"Datum",-11}  {"Kund",-21}  {"Totalvärde",-11}  {"Produktnamn",-21}" +
                $"  {"Kvantitet",-11}  {"Enhetspris"}");

            foreach (var group in groups)
            {
                string formattedDate = group.First().OrderDate.ToString("yyyy-MM-dd");
                Console.Write($"{group.Key,-8} | {formattedDate,-10} | {group.First().CustomerName,-20} |" +
                    $" {group.First().TotalAmount,-10} | ");

                foreach (var item in group)
                {
                    Console.SetCursorPosition(60, Console.CursorTop);
                    Console.WriteLine($"{item.Name,-20} | {item.Quantity,-10} | {item.UnitPrice}");
                }
            }

            Console.ReadLine();
        }
    }
}
