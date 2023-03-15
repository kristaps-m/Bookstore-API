namespace Bookstore.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }

        public Book(int id, string title, string author, DateTime publicationDate)
        {
            Id = id;
            Title = title;
            Author = author;
            PublicationDate = publicationDate;
        }
    }
}
