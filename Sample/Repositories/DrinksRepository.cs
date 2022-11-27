using Sample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public class DrinksRepository
    {
        public List<Drinks> Drinks = new List<Drinks>();

        public List<Drinks> AllItems()
        {
            return Drinks;
        }

        public Drinks GetItemById(string itemId)
        {
            return Drinks.SingleOrDefault(x => x.Id.ToString() == itemId);
        }

        public List<Drinks> ReadDrinksFromTxt()
        {
            string filePath = @"C:\Users\lauki\OneDrive\Desktop\Sample\Sample\Drinks.txt";
            //List<Food> foods = new List<Food>();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                Drinks newDrink = new Drinks();
                newDrink.Id = Convert.ToInt32(entries[0]);
                newDrink.Name = entries[1];
                newDrink.Price = Convert.ToDecimal(entries[2]);
                newDrink.DaysUntilExpired = Convert.ToInt32(entries[3]);
                Drinks.Add(newDrink);
            }
            return Drinks;
        }
    }
}
