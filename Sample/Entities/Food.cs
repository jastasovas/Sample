using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entities
{
    public class Food
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int DaysUntilExpired { get; set; }

        public Food() { }

        public Food(int id, string name, decimal price, int daysUntilExpired)
        {
            Id = id;
            Name = name;
            Price = price;
            DaysUntilExpired = daysUntilExpired;
        }
    }
}
