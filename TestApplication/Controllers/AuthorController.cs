using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.DataConnection.Services;
using TestApplication.DataConnection.ViewModels;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
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

    }
}
