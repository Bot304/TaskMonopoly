using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskMonopoly.Models
{
    internal class Boxes
    {
        public List<Box> listbox { get; set; }
        public Boxes() 
        {
            listbox = new List<Box>()
            {
                new Box(800, 144, 1200, 15, "5.9.2022"),
                new Box(50, 70, 90, 19, "4.3.2020"),
                new Box(150, 150, 150, 4, "1.7.2021"),
                new Box(200, 50, 400, 18, "8.5.2020"),
                new Box(850, 144, 1200, 15, "1.4.2021"),
                new Box(700, 46, 900, 26, "15.3.2022"),
                new Box(890, 48, 1300, 34, "11.6.2020"),
                new Box(87, 55, 87, 9, "3.2.2019")
            };
        }
    }
}
