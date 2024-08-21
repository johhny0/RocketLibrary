namespace LivrariaRocketApi.Models;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public double Price { get; set; }

    public int AmountAvailable { get; set; }

    public List<string> Authors { get; set; } = [];

    public List<string> Genders { get; set; } = [];

    public void FromBookRequest(BookRequest bookRequest)
    {
        Title = bookRequest.Title;
        Price = bookRequest.Price;
        AmountAvailable = bookRequest.AmountAvailable;
        Authors = bookRequest.Authors;
        Genders = bookRequest.Genders;
    }
}

public class BookRequest
{
    public string Title { get; set; } = string.Empty;

    public double Price { get; set; }

    public int AmountAvailable { get; set; }

    public List<string> Authors { get; set; } = [];

    public List<string> Genders { get; set; } = [];

    public Book ToBook()
    {
        return new Book()
        {
            AmountAvailable = AmountAvailable,
            Authors = Authors,
            Genders = Genders,
            Title = Title,
            Price = Price
        };
    }
}
