using DataAccess.Entity;

namespace Repository.Serviees;

public interface IBookRepository
{
    Guid WriteBook (Book book);
    void DeleteBook (Guid bookId);
    void UpdateBook (Book book);
    List<Book> GetAllBooks ();
    Book GetBookById (Guid bookId);
}