using E_commerce_program.Models;

namespace E_commerce_program
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ECommerceProgramContext context = new ECommerceProgramContext();

            Console.WriteLine("1. Hämta alla produkter i kategorin \"Electronics\" och sortera dem efter pris (högst först)");
            Console.WriteLine("2. Lista alla leverantörer som har produkter med ett lagersaldo under 10 enheter");
            Console.WriteLine("3. Beräkna det totala ordervärdet för alla ordrar gjorda under den senaste månaden");
            Console.WriteLine("4. Hitta de 3 mest sålda produkterna baserat på OrderDetail-data");
            Console.WriteLine("5. Lista alla kategorier och antalet produkter i varje kategori");
            Console.WriteLine("6. Hämta alla ordrar med tillhörande kunduppgifter och orderdetaljer där totalbeloppet överstiger 1000 kr");

            while (true)
            {
                int choice = MenuOptionOnKeyPress();

                switch (choice)
                {
                    case 1:
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
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
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
