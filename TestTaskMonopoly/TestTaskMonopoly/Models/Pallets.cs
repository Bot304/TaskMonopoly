using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskMonopoly.Models
{
    internal class Pallets
    {
        public List<Pallet> listpallete { get; set; }
        public Pallets() 
        {
            listpallete = new List<Pallet>()
            {
                new Pallet(800, 144, 1200),
                new Pallet(800, 144, 1200),
                new Pallet(800, 144, 1200),
                new Pallet(800, 144, 1200),
                new Pallet(1000, 144, 1200),
                new Pallet(1000, 144, 1200),
                new Pallet(1000, 144, 1200),
                new Pallet(1000, 144, 1200)
            };
        }
    }
}
