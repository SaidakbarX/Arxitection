
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Dto;

namespace ArxitectionBookService.Controllers
{
    public class BookController : Controller
    {
        private IBookService _bookService;
        public BookController()
        {
            _bookService = new BookService();
        }
        [HttpPost("add book")]
        public Guid AddBook (BookDto book)
        {
            _bookService.AddBook(book);
            return book.Id;
        }
        [HttpDelete ("delet book")]
        public void DeleteBook (Guid bookId)
        {
            _bookService.DeleteBook(bookId);
        }
        [HttpGet ("get all book")]
        public List<BookDto> GetBooks ()
        {
            return _bookService.GetAllBooks();
        }
        [HttpPut ("update book")]
        public void Update (BookDto book)
        {
            _bookService.UpdateBook(book);
        }

    }
}
