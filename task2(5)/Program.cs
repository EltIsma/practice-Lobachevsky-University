public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public double Price { get; set; }

    public Book(string title, string author, double price)
    {
        Title = title;
        Author = author;
        Price = price;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Title: {Title}, Author: {Author}, Price: {Price}");
    }
}

public class BookGenre : Book
{
    public string Genre { get; set; }

    public BookGenre(string title, string author, double price, string genre)
        : base(title, author, price)
    {
        Genre = genre;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Genre: {Genre}");
    }
}

public sealed class BookGenrePubl : BookGenre
{
    public string Publisher { get; set; }

    public BookGenrePubl(string title, string author, double price, string genre, string publisher)
        : base(title, author, price, genre)
    {
        Publisher = publisher;
    }

    public override void Print()
    {
        base.Print();
        Console.WriteLine($"Publisher: {Publisher}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        var book1 = new Book("Book1", "Author1 Ivanov", 100);
        book1.Print();

        var bookGenre1 = new BookGenre("BookGenre1", "AuthorGenre1", 150, "Genre1");
        bookGenre1.Print();

        var bookGenrePubl1 = new BookGenrePubl("BookGenrePubl1", "AuthorGenrePubl1", 200, "GenrePubl1", "Publisher1");
        bookGenrePubl1.Print();
    }
}