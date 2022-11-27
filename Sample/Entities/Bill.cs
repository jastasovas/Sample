using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entities
{
    public class Bill
    {

        public string Name { get; set; }
        public List<Table> Tables { get; set; }
        public List<Food> Foods { get; set; }
        public List<Drinks> Drinks { get; set; }


        List<Bill> Bills { get; set; } = new List<Bill>();

        public Bill() { }

        public Bill(string name, List<Table> tables, List<Food> foods, List<Drinks> drinks)
        {

            Name = name;
            Tables = tables;
            Foods = foods;
            Drinks = drinks;

        }
    }
}
