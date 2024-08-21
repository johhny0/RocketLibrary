using LivrariaRocketApi.Models;

namespace LivrariaRocketApi.Services;

public class BookService
{
    private static readonly List<Book> books =
    [
        new() {
                Id =1,
                Title = "Harry Potter e a Pedra Filosofal",
                Price = 40.42,
                AmountAvailable = 5,
                Authors = ["J. K. Rowling"],
                Genders = ["Fantasy", "Drama"]
            },
            new() {
                Id =2,
                Title = "Harry Potter e a Câmara Secreta",
                Price = 54.70,
                AmountAvailable = 15,
                Authors = ["J. K. Rowling"],
                Genders = ["Fantasy", "Drama"]
            },
            new() {
                Id = 3,
                Title = "Harry Potter e o Prisioneiro de Azkaban",
                Price = 42.23,
                AmountAvailable = 15,
                Authors = ["J. K. Rowling"],
                Genders = ["Fantasy", "Drama"]
            },
            new() {
                Id = 4,
                Title = "It Ends with Us",
                Price = 43.67,
                AmountAvailable = 15,
                Authors = ["Colleen Hoover"],
                Genders = ["Romance"]
            },
        ];


    public List<Book> GetAll()
    {
        return books;
    }

    public IEnumerable<Book> GetByGenre(string genre)
    {
        return books.Where(b => b.Genders.Any(g => g == genre));
    }

    public IEnumerable<Book> GetByAuthor(string author)
    {
        return books.Where(b => b.Authors.Any(a => a.Equals(author, StringComparison.InvariantCulture)));
    }

    public Book? GetById(int id)
    {
        return books.FirstOrDefault(b => b.Id == id);
    }

    public Book Create(BookRequest bookRequest)
    {
        var book = bookRequest.ToBook();

        book.Id = books.Count() + 1;

        books.Add(book);

        return book;
    }

    public Book? Update(int id, BookRequest bookRequest)
    {
        var book = books.FirstOrDefault(b => b.Id == id);

        if (book is null) return null;

        book.FromBookRequest(bookRequest);

        return book;
    }

    public bool Remove(int id)
    {
        var bookToRemove = books.FirstOrDefault(b => b.Id == id);

        if (bookToRemove is null) return false;
        
        books.Remove(bookToRemove);

        return true;
    }
}
