namespace Your_Own_Library;

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public string Genre { get; set; }
    public string BriefDescription { get; set; }

    public Book(string title, string author, int pages, string genre, string briefDescription)
    {
        Title = title;
        Author = author;
        Pages = pages;
        Genre = genre;
        BriefDescription = briefDescription;
    }

    public void DisplayBookInfo()
    {
        Console.WriteLine($"{Title}, {Author}, {Pages}, {Genre}, {BriefDescription}");
    }
}