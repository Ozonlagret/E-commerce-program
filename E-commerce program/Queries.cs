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
    }
}
