using KutuphaneSistemi;
using System.Diagnostics;

namespace LibrarySystem
{
    public class Library
    {
        public static List<Book> booksList = new List<Book>();
        public static List<BorrowBooks> borrowBooksList = new List<BorrowBooks>();
        public static void Main(string[] args)
        {
            int i = 0;
            while (i == 0)
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("    Kütüphanemize Hoşgeldiniz    ");
                Console.WriteLine("*********************************");
                Console.WriteLine("1. Yeni Kitap Ekle");
                Console.WriteLine("2. Tüm Kitapları Listele");
                Console.WriteLine("3. Kitap Sil");
                Console.WriteLine("4. Kitap Ara");
                Console.WriteLine("5. Kitap Ödünç Al");
                Console.WriteLine("6. Kitap İade Et");
                Console.WriteLine("7. Ödünç Alınan Kitapları Listele");
                Console.WriteLine("8. İade Süresi Geçmiş Kitapları Listele");
                Console.WriteLine("0. Çıkış");
                Console.Write("İşlem Seçiniz: ");
                string islem = Console.ReadLine();
                switch (islem)
                {
                    case "1":
                        Console.Clear();
                        AddBook();
                        break;
                    case "2":
                        Console.Clear();
                        ListBooks();
                        break;
                    case "3":
                        Console.Clear();
                        DeleteBook();
                        break;
                    case "4":
                        Console.Clear();
                        SearchBook();
                        break;
                    case "5":
                        Console.Clear();
                        BorrowBook();
                        break;
                    case "6":
                        Console.Clear();
                        ReturnBook();
                        break;
                    case "7":
                        Console.Clear();
                        ListBorrowBooks();
                        break;
                    case "8":
                        Console.Clear();
                        ListExpiredBooks();
                        break;
                    case "0":
                        i = 1;
                        break;
                    default:
                        Console.WriteLine("******************************");
                        Console.WriteLine("Hatalı İşlem");
                        Console.WriteLine("******************************");
                        break;
                }
            }
        }

        

        private static void AddBook()
        {
            int isbn = 0;
            byte copy = 0;

            Console.Write("Kitap Adı Giriniz: ");
            string name = Console.ReadLine();
            if(name.Length == 0)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Kitap Adı Boş Olamaz!");
                Console.WriteLine("******************************");
                return;
            }

            Console.Write("Yazar Adı Giriniz: ");
            string author = Console.ReadLine();
            if (author.Length == 0)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Yazar Adı Boş Olamaz!");
                Console.WriteLine("******************************");
                return;
            }

            try
            {
                Console.Write("Kitap ISBN Giriniz: ");
                isbn = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Lütfen Bir Sayı Giriniz!");
                Console.WriteLine("******************************");
                return;
            }
            catch(OverflowException)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("ISBN Maksimum 8 Haneli Olabilir.");
                Console.WriteLine("******************************");
                return;
            }

            try
            {
                Console.Write("Kopya Sayısı Giriniz: ");
                copy = Convert.ToByte(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Lütfen Bir Sayı Giriniz!");
                Console.WriteLine("******************************");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Kopya Sayısı Maksimum 255 Olabilir!");
                Console.WriteLine("******************************");
                return;
            }

            Book kitap = new Book(booksList.Count+1, name, author, isbn, copy, 0);
            booksList.Add(kitap);
        }

        private static void DeleteBook()
        {
            ListBooks();
            Console.Write("Silmek İstediğiniz Kitap No Giriniz: ");
            int i;
            try
            {
                i = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Lütfen Bir Sayı Giriniz!");
                Console.WriteLine("******************************");
                return;
            }

            try
            {
                booksList.Remove(booksList[i - 1]);
            }
            catch (Exception)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Girilen No Listede Bulunamadı!");
                Console.WriteLine("******************************");
                return;
            }
            foreach (var item in booksList)
            {
                item.No -= 1;
            }
        }

        private static void SearchBook()
        {
            Console.WriteLine("1. Yazar Adı İle Arama");
            Console.WriteLine("2. Kitap Adı İle Arama");
            Console.Write("İşlem Seçiniz: ");
            string i = Console.ReadLine();
            switch (i)
            {
                case "1":
                    SearchAuthorName();
                    break;
                case "2":
                    SearchBookName();
                    break;
                default:
                    Console.WriteLine("******************************");
                    Console.WriteLine("Hatalı İşlem");
                    Console.WriteLine("******************************");
                    break;
            }
        }

        private static void SearchBookName()
        {
            Console.Write("Aramak İstediğiniz Kitabın Adını Giriniz: ");
            string i = Console.ReadLine();
            int k = 0;
            foreach (var item in booksList)
            {
                if (item.Name == i)
                {
                    k++;
                    Console.WriteLine("******************************");
                    Console.Write("Kitap No: ");
                    Console.WriteLine(item.No);
                    Console.Write("Kitap Adi: ");
                    Console.WriteLine(item.Name);
                    Console.Write("Kitap Yazari: ");
                    Console.WriteLine(item.Author);
                    Console.Write("Kitap ISBN: ");
                    Console.WriteLine(item.ISBN);
                    Console.Write("Kitap Kopya Sayisi: ");
                    Console.WriteLine(item.Copy);
                    Console.Write("Kitap Odunc Sayisi: ");
                    Console.WriteLine(item.Borrow);
                    Console.WriteLine("******************************");
                }
            }
            if (k == 0)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Aradığınız Kitap Bulunamadı!");
                Console.WriteLine("******************************");
            }
        }

        private static void SearchAuthorName()
        {
            Console.Write("Aramak İstediğiniz Yazarın Adını Giriniz: ");
            string i = Console.ReadLine();
            int k = 0;
            foreach (var item in booksList)
            {
                if (item.Author == i)
                {
                    k++;
                    Console.WriteLine("******************************");
                    Console.Write("Kitap No: ");
                    Console.WriteLine(item.No);
                    Console.Write("Kitap Adı: ");
                    Console.WriteLine(item.Name);
                    Console.Write("Kitap Yazarı: ");
                    Console.WriteLine(item.Author);
                    Console.Write("Kitap ISBN: ");
                    Console.WriteLine(item.ISBN);
                    Console.Write("Kitap Kopya Sayısı: ");
                    Console.WriteLine(item.Copy);
                    Console.Write("Kitap Ödunç Sayısı: ");
                    Console.WriteLine(item.Borrow);
                    Console.WriteLine("******************************");
                }
            }
            if (k == 0)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Aradığınız Yazar Bulunamadı!");
                Console.WriteLine("******************************");
            }
        }

        private static void BorrowBook()
        {
            ListBooks();
            Console.Write("Ödünç Almak İstediğiniz Kitap No Giriniz: ");
            try
            {
                int i = Convert.ToInt32(Console.ReadLine());
                if(booksList[i - 1].Copy > 0)
                {
                    booksList[i - 1].Borrow++;
                    booksList[i - 1].Copy--;
                    BorrowBooks borrowBook = new BorrowBooks(borrowBooksList.Count + 1, booksList[i - 1].Name, booksList[i - 1].Author, booksList[i - 1].ISBN, DateTime.Now);
                    borrowBooksList.Add(borrowBook);
                }
                else
                {
                    Console.WriteLine("******************************");
                    Console.WriteLine("Ödünç Alınabilir Kopya Bulunmamaktadır!");
                    Console.WriteLine("******************************");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Lütfen Doğru Bir Sayı Giriniz!");
                Console.WriteLine("******************************");
            }
        }

        private static void ListBorrowBooks()
        {
            if(borrowBooksList.Count == 0)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Ödünç Kitap Kaydı Bulunamadı!");
                Console.WriteLine("******************************");
            }
            else
            {
                foreach (var item in borrowBooksList)
                {
                    Console.WriteLine("******************************");
                    Console.Write("Kitap No: ");
                    Console.WriteLine(item.No);
                    Console.Write("Kitap Adı: ");
                    Console.WriteLine(item.Name);
                    Console.Write("Kitap Yazarı: ");
                    Console.WriteLine(item.Author);
                    Console.Write("Kitap ISBN: ");
                    Console.WriteLine(item.ISBN);
                    Console.Write("Ödünç Alma Tarihi: ");
                    Console.WriteLine(item.BorrowDate);
                    Console.Write("İade Edileceği Tarih: ");
                    Console.WriteLine(item.ReturnDate);
                    Console.WriteLine("******************************");
                }
            }
        }

        private static void ListExpiredBooks()
        {
            int k = 0;
            foreach (var item in borrowBooksList)
            {
                if(item.ReturnDate < DateTime.Now)
                {
                    k++;
                    Console.WriteLine("******************************");
                    Console.Write("Kitap No: ");
                    Console.WriteLine(item.No);
                    Console.Write("Kitap Adı: ");
                    Console.WriteLine(item.Name);
                    Console.Write("Kitap Yazarı: ");
                    Console.WriteLine(item.Author);
                    Console.Write("Kitap ISBN: ");
                    Console.WriteLine(item.ISBN);
                    Console.Write("Ödünç Alma Tarihi: ");
                    Console.WriteLine(item.BorrowDate);
                    Console.Write("İade Edileceği Tarih: ");
                    Console.WriteLine(item.ReturnDate);
                    Console.WriteLine("******************************");
                }
            }
            if(k == 0)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("İade Süresi Geçmiş Kitap Bulunamadı!");
                Console.WriteLine("******************************");
            }
        }

        private static void ReturnBook()
        {
            ListBorrowBooks();
            Console.Write("İade Etmek İstediğini Kitap No Giriniz: ");
            int i = Convert.ToInt32(Console.ReadLine());
            foreach (var item in booksList)
            {
                if (item.Name == booksList[i-1].Name && item.Author == booksList[i - 1].Author)
                {
                    booksList[i - 1].Borrow--;
                    booksList[i - 1].Copy++;
                }
            }
            try
            {
                borrowBooksList.Remove(borrowBooksList[i - 1]);
            }
            catch (Exception)
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Lütfen Doğru Bir Sayı Giriniz!");
                Console.WriteLine("******************************");
                return;
            }
        }

        private static void ListBooks()
        {
            if(booksList.Count > 0)
            {
                foreach (var item in booksList)
                {
                    Console.WriteLine("******************************");
                    Console.Write("Kitap No: ");
                    Console.WriteLine(item.No);
                    Console.Write("Kitap Adı: ");
                    Console.WriteLine(item.Name);
                    Console.Write("Kitap Yazarı: ");
                    Console.WriteLine(item.Author);
                    Console.Write("Kitap ISBN: ");
                    Console.WriteLine(item.ISBN);
                    Console.Write("Kitap Kopya Sayısı: ");
                    Console.WriteLine(item.Copy);
                    Console.Write("Kitap Ödünç Sayısı: ");
                    Console.WriteLine(item.Borrow);
                    Console.WriteLine("******************************");
                }
            }
            else
            {
                Console.WriteLine("******************************");
                Console.WriteLine("Kütüphaneye Kayıtlı Kitap Bulunmamaktadır.");
                Console.WriteLine("******************************");
            }
            
        }
    }
}
