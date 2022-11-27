using Sample.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public class BillRepository
    {
        public List<Bill> Bills { get; set; } = new List<Bill>();

        public BillRepository()
        {

        }

        public void AddBill(Bill billet)
        {
            Bills.Add(billet);
        }

        public List<Bill> AllBills()
        {
            return Bills;
        }

        public Bill GetBillByName(string? billName)
        {
            return Bills.FirstOrDefault(x => x.Name == billName);
        }
    }
}
