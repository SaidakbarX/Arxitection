using DataAccess.Entity;
using System.Text.Json;

namespace Repository.Serviees;

public class BookRepository : IBookRepository
{
    private string _path;
    private List<Book> _books;
    public BookRepository()
    {
        _path = Path.Combine(Directory.GetCurrentDirectory(), "Book.json");
        if (!File.Exists(_path))
        {
            File.WriteAllText(_path, "[]");
        }
        _books = GetAllBooks();
    }
    public void DeleteBook(Guid bookId)
    {
        _books.Remove(GetBookById(bookId));
        SaveData();
    }

    public List<Book> GetAllBooks()
    {
        var bookJson = File.ReadAllText(_path);
        var books = JsonSerializer.Deserialize<List<Book>>(bookJson);
        return books;
    }

    public Book GetBookById(Guid bookId)
    {
        var book =_books.FirstOrDefault(bk => bk.Id == bookId);
        if (book == null)
        {
            throw new Exception("itst not Id");
        }
        return book;
    }

    public void UpdateBook(Book book)
    {
        _books[_books.IndexOf(book)] = book;
        SaveData();
    }

    public Guid WriteBook(Book book)
    {
        _books.Add(book);
        book.Id = Guid.NewGuid();
        SaveData();
        return book.Id;
    }
    private void SaveData()
    {
        var bookJson = JsonSerializer.Serialize(_books);
        File.WriteAllText(_path, bookJson);
    }
}
