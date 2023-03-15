using Bookstore.Core.Models;

namespace Bookstore.Data
{
    public interface IBookStorage
    {
        Book AddBook(Book book);
        Book GetBook(int id);
        List<Book> GetAllBooks();
        List<List<string>> GetAdmins();
    }
}