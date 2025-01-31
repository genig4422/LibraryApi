using System.Threading;
using Microsoft.EntityFrameworkCore;
using TestApplication.DataConnection.Models;
using TestApplication.DataConnection.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestApplication.DataConnection.Services
{
    public class BooksService
    {
        private AppDbContext _context;
        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBookWithAuthors(BookVM book) 
        {
            var _book = new Book()
            {
                Title = book.Title,
                ISBN = book.ISBN,
                PublisherId = book.PublisherId,
               

            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds) {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };

                _context.Books_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }


        public List<BookResponseVM> GetAllBooks()
        {
            return _context.Books
                .Include(b => b.Publisher) // Include Publisher
               
                .Include(b => b.Book_Authors) // Include Book_Authors
                    .ThenInclude(ba => ba.Author) // Include Author from Book_Authors
                .Select(b => new BookResponseVM
                {
                    Id = b.Id,
                    Title = b.Title,
                    ISBN = b.ISBN,
                    PublisherName = b.Publisher.Name, // Get Publisher Name
                  
                    AuthorNames = b.Book_Authors.Select(ba => ba.Author.Name).ToList() // Get Author Names
                })
                .ToList();
        }

        public BookWithAuthorsVM GetBookById(int bookId)
        {
            var _bookWithAuthors = _context.Books.Where(n => n.Id == bookId).Select(book => new BookWithAuthorsVM()
            {

                Title = book.Title,
                ISBN = book.ISBN,
                PublisherName = book.Publisher.Name,
             
                AuthorNames = book.Book_Authors.Select(n => n.Author.Name).ToList()
            }).FirstOrDefault();

            return _bookWithAuthors;
        }
        public Book UpdateBookById(int bookId, BookEditVM book)
        {
            // Retrieve the book to update with its associated authors
            var _book = _context.Books
                .Include(b => b.Book_Authors)
                .ThenInclude(ba => ba.Author) // Include authors in the join table
                .FirstOrDefault(n => n.Id == bookId);

            if (_book == null)
            {
                // Book not found
                return null; // Or throw an exception depending on how you want to handle this
            }


            // Update the book details (Title, ISBN, Publisher, Category)
            _book.Title = book.Title;
            _book.ISBN = book.ISBN;
            _book.PublisherId = book.PublisherId;
          

            // Remove existing authors before adding the new one
            var existingAuthors = _context.Books_Authors
                .Where(ba => ba.BookId == bookId)
                .ToList();

            _context.Books_Authors.RemoveRange(existingAuthors);

            // Add only one author based on the AuthorName
            if (!string.IsNullOrEmpty(book.AuthorName)) // Assuming AuthorName is a single string now
            {
                var author = _context.Author.FirstOrDefault(a => a.Name == book.AuthorName);

                if (author != null)
                {
                    // Add the author to the Books_Authors table
                    _context.Books_Authors.Add(new Book_Author
                    {
                        BookId = _book.Id,
                        AuthorId = author.Id
                    });
                }
            }

            // Save the changes after adding the new author
            _context.SaveChanges();

            return _book; // Return the updated book
        }




        public void DeleteBookById(int bookId ) { 
            
            var _book = _context.Books.FirstOrDefault(n =>n.Id == bookId);

            if (_book != null)
            {
                _context.Books.Remove( _book );
                _context.SaveChanges();
            }
        }
    
    }
}
