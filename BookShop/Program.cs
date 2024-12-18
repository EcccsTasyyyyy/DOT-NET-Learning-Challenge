namespace BookShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book[] bookArray = new Book[10]
            {
                new Book { Title = "title1", Price = 9.99m },
                new Book { Title = "title2", Price = 10.99m },
                new Book { Title = "title3", Price = 11.99m },
                new Book { Title = "title4", Price = 34.99m },
                new Book { Title = "title5", Price = 13.99m },
                new Book { Title = "title6", Price = 20.99m },
                new Book { Title = "title7", Price = 15.99m },
                new Book { Title = "title8", Price = 77.99m },
                new Book { Title = "title9", Price = 17.99m },
                new Book { Title = "title10", Price = 24.99m },
            };

            int i = 0;
            do
            {
                Console.WriteLine($"Title: {bookArray[i].Title}, Price: {bookArray[i].Price}.");
                i++;
            } while (i < bookArray.Length);
            Console.WriteLine();

            i = 0;
            Book mostExpensiveBook = null;
            decimal maxPrice = decimal.MinValue;
            while (i < bookArray.Length)
            {
                if (bookArray[i].Price > maxPrice)
                {
                    maxPrice = bookArray[i].Price;
                    mostExpensiveBook = bookArray[i];
                }
                i++;
            }

            if (mostExpensiveBook != null)
            {
                Console.WriteLine($"The Most expensive book is: {mostExpensiveBook.Title}, {mostExpensiveBook.Price}");
            }
            Console.WriteLine();

            for(i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i].Price < 20)
                {
                    Console.WriteLine($"Title: {bookArray[i].Title}, Price: {bookArray[i].Price}");
                }
            }
            Console.WriteLine();

            Console.Write("Enter your budget: ");
            decimal budget = Convert.ToDecimal(Console.ReadLine());

            Console.WriteLine($"\nBooks you can afford with your budget {budget}");

            foreach(Book book in bookArray)
            {
                if(book.Price <= budget)
                {
                    Console.WriteLine($"- {book.Title}, {book.Price}");
                }
            }
        }
    }

    internal class Book
    {
        public string? Title { get; set; }
        public decimal Price { get; set; }
    }
}
