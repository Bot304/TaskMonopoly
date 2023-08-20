using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskMonopoly.Models
{
    public class Pallet
    {
        public static int counter = 0;
        public int Id { get; set; }
        public int width { get; set; } // Каждая коробка не должна превышать по размерам паллету (по ширине и глубине)
        public int height { get; set; }
        public int depth { get; set; } // Каждая коробка не должна превышать по размерам паллету (по ширине и глубине)
        public int weight { get; set; } // сумма всех коробок +30 кг
        public int volume { get; set; } // Объем паллеты вычисляется как сумма объема всех находящихся на ней коробок и произведения ширины, высоты и глубины паллеты
        public DateOnly ExpirationDate { get; set; } // наименьший срок годности коробки
        public List<Box> Boxes { get; set; }
        public Pallet(int width, int height, int depth)
        {
            counter++;
            Id = counter;
            this.width = width;
            this.height = height;
            this.depth = depth;
            weight = 30;
            volume = width * height * depth;
            Boxes = new List<Box>();
            ExpirationDate = new DateOnly();
        }
        public void Add (Box box) 
        {
            if ((box.width * box.depth) < (width * depth)) 
            {
                weight = weight + box.weight;
                volume = volume + box.volume;

                Boxes.Add(box);

                ExpirationDate = box.ExpirationDate;

                foreach (var bx in Boxes)
                {
                    if (bx.ExpirationDate < ExpirationDate)
                    {
                        ExpirationDate = bx.ExpirationDate;
                    }
                }
                Console.WriteLine("Коробка на паллете");
            }
            else
            {
                Console.WriteLine("Многоуважаемый, коробка не влезает на паллету");
            }
            
        }
        public override string ToString()
        {
            return "id - " + Id + "\t" + width + "x" + height + "x" + depth;
        }
    }
}
