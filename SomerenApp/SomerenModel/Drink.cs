using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Drink
    {
        
        public int Id {  get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool Alcohol { get; set; }
        public int StockAmount { get; set; }
        public int AmountSold { get; set; }


        public override string ToString()
        {
            return $"id: {Id} Name: {Name}";
        }

    }
}
