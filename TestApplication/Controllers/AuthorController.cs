using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.DataConnection.Services;
using TestApplication.DataConnection.ViewModels;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowLocalhostOrigins")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorsService _authorsService;

        public AuthorController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM author)
        {
            _authorsService.AddAuthor(author);
            return Ok(author);
        }

        [HttpGet("get-authors-with-books-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id) {

            var response = _authorsService.GetAuthorWithBooks(id);
            return Ok(response);


        }

        [HttpDelete("remove-author-by-id/{id}")]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorsService.DeleteAuthorById(id);
            return Ok();
        }

        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors() { 
           var allAuthors =  _authorsService.GetAllAuthors();
            return Ok(allAuthors);
        }

    }
}
