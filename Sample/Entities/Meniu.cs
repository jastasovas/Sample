using Sample.BillGenerator;
using Sample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entities
{
    public class Meniu
    {
        FoodRepository foodRepository = new FoodRepository();
        DrinksRepository drinksRepository = new DrinksRepository();
        TableRepository tableRepository = new TableRepository();
        RestaurantBillGenerator restaurantBillGenerator = new RestaurantBillGenerator();
        RestaurantBillGenerator RestaurantBillGenerator = new RestaurantBillGenerator();
        BillRepository BillRepository = new BillRepository();


        public void Init()
        {
            Console.WriteLine("[1] Take an order");
            Console.WriteLine("[2] View Invoice");
            Console.WriteLine("[3] Save Invoice to file");
            Console.WriteLine("[4] Close Program");
            var enteredValue = Console.ReadLine();

            switch (enteredValue)
            {
                case "1":
                    Console.Clear();
                    SelectTable();
                    //TakeAnOrder();
                    break;
                case "2":
                    Console.Clear();
                    ViewInvoice();

                    break;
                case "3":
                    Console.Clear();
                    //SaveInvoiceToFile();
                    break;
                case "4":
                    CloseProgram();
                    break;
                default:
                    Console.WriteLine("Wrong input!!!");
                    Init();
                    break;
            }
            Init();
        }

        public void CloseProgram()
        {
            Console.WriteLine("Press any key to close");
            Environment.Exit(0);
        }

        

        public void ViewInvoice()
        {
            Console.WriteLine("Existing bills:");
            var bills = BillRepository.AllBills();

            foreach (var invoice in bills)
            {
                Console.WriteLine(invoice.Name);
            }
            Console.WriteLine("Choose bill:");
            var selectedInvoice = Console.ReadLine();
            Console.WriteLine("You have entered a bad bill name or the bill does not exist.");
            foreach (var invoice in bills)
            {
                if (selectedInvoice == invoice.Name)
                {
                    Console.Clear();
                    RestaurantBillGenerator.ViewBill(selectedInvoice);
                }
                else
                {
                }
            }
        }
        public void SelectTable()
        {
            Console.WriteLine("List of Tables:");

            tableRepository.ReadTablesFromTxt();
            var items = tableRepository.AllTables();
            foreach (var item in items)
            {
                Console.WriteLine($"-[{item.Id}] Number of Seats : {item.NumOfSeats}");
            }
            Console.WriteLine("Choose products(Pvz.: 1,2,3 ...):");
            var enteredItemsIds = Console.ReadLine();
            var splitedItemsIds = enteredItemsIds.Split(',');
            TakeAnOrder();
            Console.WriteLine("Enter the name of the bill:");
            var billName = Console.ReadLine();
            RestaurantBillGenerator.CreateBill(billName, splitedItemsIds);
            Console.WriteLine("Invoice created!");
        }
        public void TakeAnOrder()
        {
            Console.WriteLine("List of Foods:");
            foodRepository.ReadFoodFromTxt();
            var items = foodRepository.AllItems();
            foreach (var item in items)
            {
                Console.WriteLine($"-[{item.Id}] [{item.Name}] price: {item.Price} Expired days: {item.DaysUntilExpired}");
            }
            Console.WriteLine("Choose products(Pvz.: 1,2,3 ...):");
            var enteredItemsIds = Console.ReadLine();
            var splitedItemsIds = enteredItemsIds.Split(',');


            Console.WriteLine("Does the client want a drink? Choose: y/n");
            var selected = Console.ReadLine();
            if (selected == "y")
            {
                WantDrinks();
            }
            
        }

        public void WantDrinks()
        {
            Console.WriteLine("List of Drinks:");
            drinksRepository.ReadDrinksFromTxt();
            var items = drinksRepository.AllItems();
            foreach (var item in items)
            {
                Console.WriteLine($"-[{item.Id}] [{item.Name}] price: {item.Price} ");
            }
            Console.WriteLine("Choose products(Pvz.: 1,2,3 ...):");
            var enteredItemsIds = Console.ReadLine();
            var splitedItemsIds = enteredItemsIds.Split(',');
        }


    }
}
