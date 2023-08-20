using System.Xml.Linq;
using TestTaskMonopoly.Models;

namespace TestTaskMonopoly
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Boxes boxes = new Boxes();
            Pallets pallets = new Pallets();

            var sortedbox = boxes.listbox.OrderBy(x => x.ExpirationDate).ToList();
            Console.WriteLine("Это ваши коробки, поставьте их на паллеты");
            Console.WriteLine(String.Join("\n", sortedbox));

            var sortedpallet = pallets.listpallete.OrderBy(x => x.Id).ToList();
            Console.WriteLine("\nЭто ваши паллеты");
            Console.WriteLine(String.Join("\n", sortedpallet));


            bool engine = true;

            while (engine)
            {
                
                Console.WriteLine("Для добавления коробки на палет введите Add  |  Для выхода и вывода отсортированных паллетов введите Out");
                string name = Console.ReadLine();
                switch (name)
                {
                    case "Add":
                        Console.WriteLine("Введине Id коробки");
                        string idbox = Console.ReadLine();
                        bool result1 = int.TryParse(idbox, out var idboxout);
                        if (idboxout > boxes.listbox.Count() || idboxout <= 0)
                        {
                            break;
                        }

                        Console.WriteLine("Введине Id паллеты");
                        string idpallet = Console.ReadLine();
                        bool result2 = int.TryParse(idpallet, out var idpalletout);
                        if (idpalletout > pallets.listpallete.Count() || idpalletout <= 0)
                        {
                            break;
                        }

                        pallets.listpallete[idpalletout - 1].Add(boxes.listbox[idboxout - 1]);
                        break;

                    case "Out":
                        Console.WriteLine("Ваши отсортированные паллеты");
                        List<Pallet> newpallets = new List<Pallet>();
                        foreach(var pal in pallets.listpallete)
                        {
                            if(pal.Boxes.Count() > 0)
                            {
                                newpallets.Add(pal);
                                
                            }
                        }

                        var finalsort = from c in newpallets
                                        orderby c.weight, c.ExpirationDate
                                        group c by c.ExpirationDate into g
                                        select g;
                        
                                        

                        foreach(var c in finalsort)
                        {
                            Console.WriteLine(c.Key);
                            foreach (var e in c)
                            {
                                Console.WriteLine("\tid паллеты - "+ e.Id);
                                foreach(var f in e.Boxes)
                                {
                                    Console.WriteLine("\t\tid коробки - " + e.Id + "\t" + e.width + "x" + e.height + "x" + e.depth + "\tСрок годности: " + e.ExpirationDate);
                                }

                            }
                        }


                        engine = false;
                        break;
                    default:
                        Console.WriteLine("Введена неправильная команда");
                        break;
                }
            }
            


            Console.ReadLine();
        }

    }
}