namespace School_Library_Manager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] categoryArr = { @"Children's literature", @"Scientific literature" };

            string[][] bookArr = new string[2][];
            bookArr[0] = new[] { "E-Book", "book2", "book1", "book3", "book4" };
            bookArr[1] = new[] { "Printed Book", "book7", "book5", "book6" };

            for (int i = 0; i < categoryArr.Length; i++)
            {
                Console.WriteLine($"\t{categoryArr[i]}");
                Array.Sort(bookArr[i]);
                for (int j = 0; j < bookArr[i].Length; j++)
                {
                    Console.WriteLine(bookArr[i][j]);
                }
            }

            object eBook = bookArr[0][4];
            object pBook = bookArr[1][3];

            if (eBook is string)
            {
                Console.WriteLine($"\nThe book is {eBook}");
            }

            string? elBook = eBook as string;
            if (elBook != null)
            {
                if (elBook == "E-Book")
                {
                    Console.WriteLine("This is an eBook.");
                }
                else if (elBook == "Printed Book")
                {
                    Console.WriteLine("This is a Printed Book");
                }
                else
                {
                    Console.WriteLine("Unknown book type");
                }
            }

            if (pBook is string)
            {
                Console.WriteLine($"\nThe book is {pBook}");
            }

            string? printedBook = pBook as string;
            if (printedBook != null)
            {
                if (printedBook == "Printed Book")
                {
                    Console.WriteLine("This is a Printed Book");
                }
                else if (printedBook == "E-Book")
                {
                    Console.WriteLine("This is an E-Book");
                }
                else
                {
                    Console.WriteLine("Unknown book type");
                }
            }

            Console.Write("\nEnter book name: ");
            string? userInput = Console.ReadLine();

            for (int i = 0; i < categoryArr.Length; i++)
            {
                for (int j = 0; j < bookArr[i].Length; j++)
                {
                    if (userInput == bookArr[i][j])
                    {
                        Console.WriteLine(categoryArr[i]);
                    }
                }
            }

            int total = 0;
            for (int i = 0; i < categoryArr.Length; i++)
            {
                int bookCount = bookArr[i].Length;
                Console.WriteLine($"Amount of books in {categoryArr[i]}: {bookCount}");
                total += bookCount;
            }

            Console.WriteLine($"Total amount of books: {total}");
        }
    }
}
