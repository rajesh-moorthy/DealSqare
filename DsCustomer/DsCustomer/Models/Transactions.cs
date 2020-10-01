using System;
using SQLite;

namespace Notes.Models
{
    public class Transactions
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int Discount { get; set; }
    }
}
