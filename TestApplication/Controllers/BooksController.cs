﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.DataConnection.Services;
using TestApplication.DataConnection.ViewModels;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowLocalhostOrigins")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost("add-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksService.AddBookWithAuthors(book);
            return Ok(book);
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBook() {
            var allBooks = _booksService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id) {
            var book = _booksService.GetBookById(id);
            return Ok(book);
        }

        [HttpPut("update-book-by-id/{id}")]

        public IActionResult UpdateBookById(int id, [FromBody] BookEditVM book)
        {
            var updatedBook = _booksService.UpdateBookById(id, book);
            return Ok(updatedBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id) {
             _booksService.DeleteBookById(id);
            return Ok();
        }
    }
}
