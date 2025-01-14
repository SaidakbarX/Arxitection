using Services.Dto;

namespace Services;

public interface IBookService
{
    Guid AddBook (BookDto book);
    void DeleteBook (Guid id);
    void UpdateBook (BookDto book);
    List<BookDto> GetAllBooks ();
    List<BookDto> GetAllBooksByAuthor(string author); 
 BookDto GetTopRatedBook(); // rating eng baland kitob qaytarilsin
 List<BookDto> GetBooksPublishedAfterYear(int year); // year yilidan keyin nashr bo'lgan kitoblarni qaytarilsin
 BookDto GetMostPopularBook(); // eng ko'p sotilgan kitob qaytarilsin
 List<BookDto> SearchBooksByTitle(string keyword); // titleda keyword qatnashgan kitoblar royxati qaytsin
 List<BookDto> GetBooksWithinPageRange(int minPages, int maxPages);
 int GetTotalCopiesSoldByAuthor(string author); // author ga tegishli sotilgan kitoblar soni qaytarilsin
 List<BookDto> GetBooksSortedByRating(); // ratinga qarab sortlab bering. Kattadan kichikga
 List<BookDto> GetRecentBooks(int years); // shu yil ichida nashr qilingan kitoblar royxati qaytarilsin.

}