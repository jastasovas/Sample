using Sample.Entities;
using Sample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.BillGenerator
{
    public class RestaurantBillGenerator
    {
        BillRepository billRepository = new BillRepository();
        TableRepository tableRepository = new TableRepository();
        FoodRepository foodRepository = new FoodRepository();
        DrinksRepository drinksRepository = new DrinksRepository();


        public RestaurantBillGenerator() { }
        public void CreateBill(string billName, string[] itemsIds)
        {
            var tables = new List<Table>();
            var foods = new List<Food>();
            var drinks = new List<Drinks>();
            foreach (var itemId in itemsIds)
            {
                var item = tableRepository.GetItemById(itemId);
                tables.Add(item);
            }


            foreach (var itemId in itemsIds)
            {
                var item = foodRepository.GetItemById(itemId);
                foods.Add(item);
            }


            foreach (var itemId in itemsIds)
            {
                var item = drinksRepository.GetItemById(itemId);
                drinks.Add(item);
            }


            var billet = new Bill(billName, tables, foods, drinks);

            billRepository.AddBill(billet);
        }

       

        public void ViewBill(string? billName)
        {
            var bills = billRepository.AllBills();
            Bill billet = billRepository.GetBillByName(billName);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine($"Name of the bill: {billName}");
            foreach (var item in billet.Tables)
            {
                Console.WriteLine($"-[{item.Id}] [{item.NumOfSeats}]");
            }
            foreach (var item in billet.Foods)
            {
                Console.WriteLine($"-[{item.Id}] [{item.Name}] price: {item.Price}");
            }
            foreach (var item in billet.Drinks)
            {
                Console.WriteLine($"-[{item.Id}] [{item.Name}] price: {item.Price}");
            }
            //Console.WriteLine($"Amount of items: {Bill.Sum(x => x.Price)}");
            Console.WriteLine("--------------------------------------");
        }
    }
}
