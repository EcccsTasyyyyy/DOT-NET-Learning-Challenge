namespace Your_Own_Library;

public class LibraryMenu
{
    private readonly Library _library;
    public LibraryMenu(Library library)
    {
        _library = library;
    }

    public void ShowLibraryMenu()
    {
        string? userInput;
        Console.WriteLine("\n\tLibrary Menu");

        Console.WriteLine("1. Add book/books.");
        Console.WriteLine("2. Display all books.");
        Console.WriteLine("3. Search for book.");
        Console.WriteLine("4. Exit.");

        Console.Write("Enter your choice: ");
        userInput = Console.ReadLine();

        do
        {

            switch (userInput)
            {
                case "1":
                    Console.Write("How many books you want to add: ");
                    if (int.TryParse(Console.ReadLine(), out int count))
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine($"Enter details for book {i + 1}");
                            Console.Write("Title: ");
                            var title = Console.ReadLine() ?? string.Empty;

                            Console.Write("Author: ");
                            var author = Console.ReadLine() ?? string.Empty;

                            Console.Write("Pages: ");
                            var pages = int.Parse(Console.ReadLine());

                            Console.Write("Genre: ");
                            var genre = Console.ReadLine() ?? string.Empty;

                            Console.Write("Brief description: ");
                            var briefDescription = Console.ReadLine() ?? string.Empty;

                            _library.AddBook(new(title, author, pages, genre, briefDescription));
                        }
                    }
                    break;
                case "2":
                    Console.WriteLine("Displaying all books: ");
                    _library.DisplayAllBooks();
                    break;
                case "3":
                    Console.Write("Enter book title to search");
                    var bookToSearch = Console.ReadLine() ?? string.Empty;
                    _library.BookSearch(bookToSearch);
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid input please try again.");
                    break;
            }
        } while (userInput != "4");
    }
}