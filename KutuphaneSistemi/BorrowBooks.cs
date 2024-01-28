using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneSistemi
{
    public class BorrowBooks
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public BorrowBooks(int no, string name, string author, int isbn, DateTime borrowDate)
        {
            No = no;
            Name = name;
            Author = author;
            ISBN = isbn;
            BorrowDate = borrowDate;
            ReturnDate = borrowDate.AddDays(14);
        }
    }
}
