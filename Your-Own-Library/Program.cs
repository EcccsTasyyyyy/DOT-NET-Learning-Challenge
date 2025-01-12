namespace Your_Own_Library;

internal class Program
{
    static void Main(string[] args)
    {
        Console.Write($"Enter the maximum amount of book the library can hold: ");
        int bookCount;

        while (!int.TryParse(Console.ReadLine(), out bookCount) || bookCount <= 0)
        {
            Console.WriteLine("Please enter positive integer: ");
        }

        var library = new Library(bookCount);

        var menu = new LibraryMenu(library);

        menu.ShowLibraryMenu();
    }
}