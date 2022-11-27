using Sample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public class TableRepository
    {
        public List<Table> Tables = new List<Table>();
        public List<Table> AllTables()
        {
            return Tables;
        }

        public Table GetItemById(string tableId)
        {
            return Tables.Single(x => x.Id.ToString() == tableId);
        }

        public List<Table> ReadTablesFromTxt()
        {
            string filePath = @"C:\Users\lauki\OneDrive\Desktop\Sample\Sample\Tables.txt";
            //List<Food> foods = new List<Food>();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            foreach (var line in lines)
            {
                string[] entries = line.Split(',');
                Table newTable = new Table();
                newTable.Id = Convert.ToInt32(entries[0]);
                newTable.NumOfSeats = Convert.ToInt32(entries[1]);

                Tables.Add(newTable);
            }
            return Tables;
        }
    }
}
