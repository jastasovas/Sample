using Sample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public class FoodRepository
    {
        public List<Food> Foods = new List<Food>();

        public List<Food> AllItems()
        {
            return Foods;
        }

        public Food GetItemById(string itemId)
        {
            return Foods.SingleOrDefault(x => x.Id.ToString() == itemId);
        }

        public List<Food> ReadFoodFromTxt()
        {
            string filePath = @"C:\Users\lauki\OneDrive\Desktop\Sample\Sample\Foods.txt";
            //List<Food> foods = new List<Food>();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                Food newFood = new Food();
                newFood.Id = Convert.ToInt32(entries[0]);
                newFood.Name = entries[1];
                newFood.Price = Convert.ToDecimal(entries[2]);
                newFood.DaysUntilExpired = Convert.ToInt32(entries[3]);
                Foods.Add(newFood);
            }
            return Foods;
        }
    }
}
