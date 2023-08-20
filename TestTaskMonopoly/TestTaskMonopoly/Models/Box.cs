using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace TestTaskMonopoly.Models
{
    public class Box
    {
        public static int counter = 0;
        public int Id { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int depth { get; set; }
        public int weight { get; set; } 
        public int volume { get; set; } // произведение ширины, высоты и глубины
        public DateOnly ProductionDate { get; set; }
        public DateOnly ExpirationDate { get; set; }  //дата производства плюс 100 дней
        public Box(int width, int height, int depth, int weight, string date) 
        {
            counter++;
            Id = counter;
            this.width = width;
            this.height = height;   
            this.depth = depth;
            this.weight = weight;
            volume = width* height* depth;

            ProductionDate = new DateOnly();
            ProductionDate = DateOnly.Parse(date);

            ExpirationDate = new DateOnly();
            ExpirationDate = ProductionDate.AddDays(100);
        }
        public override string ToString()
        {
            return "id - " + Id + "\t" + width + "x" + height + "x" + depth + "\tСрок годности: " + ExpirationDate;
        }
    }
}
