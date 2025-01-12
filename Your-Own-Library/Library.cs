namespace Your_Own_Library;

public class Library
{
    private readonly Book[] _books;
    private int bookCount;

    public Library(int capacity)
    {
        _books = new Book[capacity];
        bookCount = 0;
    }

    public void AddBook(Book book)
    {
        if (bookCount < _books.Length)
        {
            _books[bookCount++] = book;
            Console.WriteLine($"Book added: {book.Title}");
        }
        else
        {
            Console.WriteLine("Library is full. Can not add more books.");
        }
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine("Library Catalog: ");

        for (int i = 0; i < bookCount; i++)
            _books[i].DisplayBookInfo();
    }


    public void BookSearch(string? bookToSearch)
    {
        Console.Write("Enter book title to search: ");
        bookToSearch = Console.ReadLine();

        foreach (var book in _books)
            if (book != null && book.Title == bookToSearch)
                book.DisplayBookInfo();
            else
                throw new ArgumentException();
    }
}