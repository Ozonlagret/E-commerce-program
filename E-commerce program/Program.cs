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
                        Queries.ListSuppliers(context);
                        break;

                    case 3: // Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden
                        Queries.CalculateOrderValue(context);
                        break;

                    case 4: // Hitta de 3 mest sålda produkterna baserat på OrderDetail-data
                        Queries.FindMostSoldProducts(context);
                        break;

                    case 5: // Lista alla kategorier och antalet produkter i varje kategori
                        Queries.CategoriesContainedProducts(context);
                        break;

                    case 6: // Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr
                        Queries.GetOrderAndCustomerData(context);
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
