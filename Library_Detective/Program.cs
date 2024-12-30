namespace Library_Detective
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LetsPlay();
        }

        static Random random = new Random();

        static int[] CreateLibrary(int bookAmount)
        {
            int[] library = new int[bookAmount];
            for (int i = 0; i < library.Length; i++)
                library[i] = i + 1;
            return library;
        }

        static int HideBook(int[] library)
        {
            return library[random.Next(0, library.Length)];
        }

        static void LetsPlay()
        {
            Console.WriteLine("Greetings Library Detective!");
            Console.WriteLine("How many books are in the library? (100-1000000):");
            int bookAmount = int.Parse(Console.ReadLine());

            int[] library = CreateLibrary(bookAmount);

            int lostBook = HideBook(library);

            Console.WriteLine($"The book with number {lostBook} is lost. How would you like to search it?");
            Console.WriteLine("1 - Linear Search");
            Console.WriteLine("2 - Binary Search");
            Console.WriteLine("3 - Jump Search");

            int choice = int.Parse(Console.ReadLine());

            int steps = 0;

            int bookIndex = -1;

            if (choice == 2 || choice == 3)
                Array.Sort(library);

            switch (choice)
            {
                case 1:
                    bookIndex = LinearSearch(library, lostBook, ref steps);
                    break;
                case 2:
                    bookIndex = BinarySearch(library, lostBook, ref steps);
                    break;
                case 3:
                    bookIndex = JumpSearch(library, lostBook, ref steps);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    return;
            }

            if (bookIndex != -1)
                Console.WriteLine($"Congrats! you found the book after {steps} step!");
            else
                Console.WriteLine("Unfortunately, you could not find the book, try again");

        }

        static int LinearSearch(int[] library, int bookToFind, ref int steps)
        {
            steps++;
            for (int i = 0; i < library.Length; i++)
            {
                if (library[i] == bookToFind)
                    return i;
            }

            return -1;
        }

        static int BinarySearch(int[] sortedBookArray, int bookToFind, ref int steps)
        {
            int first = 0;
            int last = sortedBookArray.Length - 1;
            steps = 0;

            while (first <= last)
            {
                steps++;

                int middle = (first + last) / 2;
                if (sortedBookArray[middle] == bookToFind)
                    return middle;
                if (sortedBookArray[middle] < bookToFind)
                    first = middle + 1;
                else
                    last = middle - 1;
            }
            return -1;
        }

        static int JumpSearch(int[] sortedBookArray, int bookToFind, ref int steps)
        {
            int bookAmount = sortedBookArray.Length;
            int jump = (int)Math.Sqrt(bookAmount);
            int previous = 0;
            steps = 0;

            while (sortedBookArray[Math.Min(jump, bookAmount) - 1] < bookToFind)
            {
                steps++;
                previous = jump;
                jump += (int)Math.Sqrt(bookAmount);
                if (previous >= bookAmount)
                    return -1;
            }

            while (sortedBookArray[previous] < bookToFind)
            {
                previous++;
                if (previous == Math.Min(jump, bookAmount))
                    return -1;
            }

            if (sortedBookArray[previous] == bookToFind)
                return previous;

            return -1;
        }
    }
}
