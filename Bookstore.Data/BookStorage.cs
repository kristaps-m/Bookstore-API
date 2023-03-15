using Bookstore.Core.Models;

namespace Bookstore.Data
{
    public class BookStorage : IBookStorage
    {
        private List<Book> _booksStorage = new() {
            // Source: https://en.wikipedia.org/wiki/List_of_best-selling_books
            new (1, "Don Quixote", "Miguel de Cervantes", new DateTime(1605,01,01)),
            new (2, "A Tale of Two Cities", "Charles Dickens", new DateTime(1859,01,01)),
            new (3, "The Little Prince", "Antoine de Saint-Exupéry", new DateTime(1943,01,01)),
            new (4, "Harry Potter and the Philosopher's Stone", "J. K. Rowling", new DateTime(1997,01,01)),
            new (5, "And Then There Were None", "Agatha Christie", new DateTime(1939,01,01)),
            new (6, "Dream of the Red Chamber", "Cao Xueqin", new DateTime(1791,01,01)),
            new (7, "The Hobbit", "J. R. R. Tolkien", new DateTime(1937,01,01)),
            new (8, "The Lion, the Witch and the Wardrobe", "C. S. Lewis", new DateTime(1950,01,01)),
            new (9, "She: A History of Adventure", "H. Rider Haggard", new DateTime(1887,01,01)),
        };
        private int _id = 10;
        // pw = BOOK2000store
        private List<List<string>> Admins = new()  { new(){ "kristapsmitins", "Qk9PSzIwMDBzdG9yZQ==" } };

        public Book AddBook(Book book)
        {
            book.Id = _id++;
            if (_booksStorage.All(b => b.Title.ToLower().Trim() != book.Title.ToLower().Trim()))
            {
                _booksStorage.Add(book);
            }
            else
            {
                return null;
            }

            return book;            
        }

        public Book GetBook(int id)
        {
            if (id <= _booksStorage.Count && id >= 0)
            {
                return _booksStorage.FirstOrDefault(b => b.Id == id);
            }

            return null;
        }

        public List<Book> GetAllBooks()
        {
            return _booksStorage.OrderByDescending(b => b.PublicationDate).ToList();
        }

        public List<List<string>> GetAdmins()
        {
            return Admins;
        }
    }
}