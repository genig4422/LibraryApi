using Microsoft.EntityFrameworkCore;
using TestApplication.DataConnection.Models;
using TestApplication.DataConnection.ViewModels;

namespace TestApplication.DataConnection.Services
{
    public class PublisherService
    {
        private AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name,

            };
            _context.Publisher.Add(_publisher);
            _context.SaveChanges();
        }

        public List<Publisher> GetAllPublishers()
        {
            return _context.Publisher.ToList();

        }


        public PublisherWithBooksAndAuthorsVM GetPublisherData(int publisherId)
        {
            var _publisherData = _context.Publisher
                .Where(p => p.Id == publisherId)
                .Select(p => new PublisherWithBooksAndAuthorsVM()
                {
                    Name = p.Name,
                    BookAuthors = p.Books.Select(b => new BookAuthorVM()
                    {
                        BookName = b.Title,
                        BookAuthors = b.Book_Authors.Select(ba => ba.Author.Name).ToList()
                    }).ToList()
                })
                .FirstOrDefault(); // Ensure we get a single result

            return _publisherData;
        }

        public void DeletePublisherById(int id)
        {
            var _publisher = _context.Publisher
                .Include(p => p.Books) // Include related books
                .FirstOrDefault(n => n.Id == id);

            if (_publisher != null)
            {
                _context.Books.RemoveRange(_publisher.Books); // Delete related books
                _context.Publisher.Remove(_publisher); // Delete the publisher
                _context.SaveChanges();
            }
        }
    }
}
