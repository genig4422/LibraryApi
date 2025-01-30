using TestApplication.DataConnection.Models;
using TestApplication.DataConnection.ViewModels;

namespace TestApplication.DataConnection.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                Name = author.Name,

            };
            _context.Author.Add(_author);
            _context.SaveChanges();
        }

        public void DeleteAuthorById(int authorId)
        {

            var _author = _context.Author.FirstOrDefault(n => n.Id == authorId);

            if (_author != null)
            {
                _context.Author.Remove(_author);
                _context.SaveChanges();
            }
        }

        public AuthorWithBooksVM GetAuthorWithBooks(int authorID)
        {
            var _author = _context.Author.Where(n => n.Id == authorID).Select(n => new AuthorWithBooksVM()
            {
                Name =n.Name,
                BookTitles = n.Book_Authors.Select(n => n.Book.Title).ToList()
            }).FirstOrDefault();

            return _author;
        }

    }
}
