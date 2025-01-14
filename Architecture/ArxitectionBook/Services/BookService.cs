using DataAccess.Entity;
using Repository.Serviees;
using Services.Dto;

namespace Services;

public class BookService : IBookService
{
    private IBookRepository _repository;
    public BookService()
    {
        _repository = new BookRepository();
    }
    public Guid AddBook(BookDto book)
    {
        
       _repository.WriteBook(ConvertToEntity(book));
        return book.Id;
    }

    public void DeleteBook(Guid id)
    {
        _repository.DeleteBook(id);
    }

    public List<BookDto> GetAllBooks()
    {
       var book = _repository.GetAllBooks();    
        var bookDtos = book.Select(bk => ConvertToDto(bk)).ToList();
        return bookDtos;
        
    }

    public List<BookDto> GetAllBooksByAuthor(string author)
    {
        return GetAllBooks().Where(bk => bk.Author == author).ToList();
    }

    public List<BookDto> GetBooksPublishedAfterYear(int year)
    {
        return GetAllBooks().Where(bk => bk.PublishedDate.Year > year).ToList();
    }

    public List<BookDto> GetBooksSortedByRating()
    {
        return GetAllBooks().OrderBy(bk => bk.Rating).ToList();
    }

    public List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages)
    {
        return GetAllBooks().Where(bk => bk.Rating > minPages && bk.Rating < maxPages).ToList();
    }

    public BookDto GetMostPopularBook()
    {
        var popularBook = GetAllBooks().Max(bk => bk.NumberOfCopiesSold);
        return GetAllBooks().First(bk => bk.NumberOfCopiesSold == popularBook);
    }

    public List<BookDto> GetRecentBooks(int years)
    {
        return GetAllBooks().Where(bk => bk.PublishedDate.Year == years).ToList();
        
    }

    public BookDto GetTopRatedBook()
    {
        var popularBook = GetAllBooks().Max(bk => bk.Rating);
        return GetAllBooks().First(bk => bk.Rating == popularBook);
    }

    public int GetTotalCopiesSoldByAuthor(string author)
    {
        return GetAllBooks().Where(bk => bk.Author == author).Sum(bk => bk.NumberOfCopiesSold);
    }

    public List<BookDto> SearchBooksByTitle(string keyword)
    {
       return GetAllBooks().Where(bk => bk.Title.Contains( keyword)).ToList();
    }

    public void UpdateBook(BookDto book)
    {
        _repository.UpdateBook(ConvertToEntity(book));
    }
    private Book ConvertToEntity (BookDto book)
    {
        return new Book
        {
            Author = book.Author,
            Id = book.Id,
            NumberOfCopiesSold = book.NumberOfCopiesSold,
            Pages = book.Pages,
            PublishedDate = book.PublishedDate,
            Rating = book.Rating,
            Title = book.Title,
        };
    }
    private BookDto ConvertToDto (Book book)
    {
        return new BookDto
        {
            Author = book.Author,
            Id = book.Id,
            Title = book.Title,
            Rating = book.Rating,
            PublishedDate = book.PublishedDate,
            Pages = book.Pages,
            NumberOfCopiesSold = book.NumberOfCopiesSold,

        };
    }
}
