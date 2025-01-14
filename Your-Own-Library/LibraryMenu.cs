namespace Your_Own_Library;

public class LibraryMenu
{
    private Library? _library;
    public void ShowLibraryMenu()
    {
        string? userInput;
        do
        {
            Console.WriteLine("\tLibrary Menu");
            Console.WriteLine("1 - Set library size.");
            Console.WriteLine("2 - Add book/books.");
            Console.WriteLine("3 - Display all books.");
            Console.WriteLine("4 - Search for book.");
            Console.WriteLine("5 - Exit.");
            Console.Write("Enter your choice: ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                case "1":
                    SetLibrarySize();
                    break;
                case "2":
                    if (EnsureLibraryInitialize())
                    {
                        AddBook();
                    }
                    break;
                case "3":
                    if (EnsureLibraryInitialize())
                    {
                        _library.DisplayAllBooks();
                    }
                    break;
                case "4":
                    if (EnsureLibraryInitialize())
                    {
                        SearchBook();
                    }
                    break;
                case "5":
                    Console.WriteLine("Exiting...");
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }
        } while (userInput != "5");
    }

    private void SetLibrarySize()
    {
        Console.Write("Enter library size: ");
        if (int.TryParse(Console.ReadLine(), out var size) && size > 0)
        {
            _library = new Library(size); ;
            Console.WriteLine($"Library size set to {size}.");
        }
        else
        {
            Console.WriteLine("Invalid library size. Please try again.");
        }
    }

    private bool EnsureLibraryInitialize()
    {
        if (_library is null)
        {
            Console.WriteLine("Please set the library size first!");
            return false;
        }
        return true;
    }

    private void AddBook()
    {
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
                if (!int.TryParse(Console.ReadLine(), out int pages))
                {
                    Console.WriteLine("Invalid page number. Skipping this book.");
                    continue;
                }

                Console.Write("Genre: ");
                var genre = Console.ReadLine() ?? string.Empty;

                Console.Write("Brief description: ");
                var briefDescription = Console.ReadLine() ?? string.Empty;

                _library.AddBook(new(title, author, pages, genre, briefDescription));
            }
        }
    }

    private void SearchBook()
    {
        Console.Write("Enter book title to search: ");
        var bookToSearch = Console.ReadLine() ?? string.Empty;
        _library.BookSearch(bookToSearch);
    }
}