using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Entities
{
    public class Table
    {
        public int Id { get; set; }
        public int NumOfSeats { get; set; }

        public Table() { }
        public Table(int id, int numOfSeats)
        {
            Id = id;
            NumOfSeats = numOfSeats;
        }
    }
}
