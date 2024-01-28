namespace LibrarySystem
{
    public class Book
    {
        public int No { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public byte Copy { get; set; }
        public byte Borrow { get; set; }

        public Book(int no, string name, string author, int isbn, byte copy, byte borrow) 
        {
            No = no;
            Name = name;
            Author = author;
            ISBN = isbn;
            Copy = copy;
            Borrow = borrow;
        }
    }
}
