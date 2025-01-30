using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApplication.DataConnection.Services;
using TestApplication.DataConnection.ViewModels;

namespace TestApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private PublisherService _publisherService;

        public PublisherController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            _publisherService.AddPublisher(publisher);
            return Ok(publisher);
        }

        [HttpGet("get-all-publishers")]

        public IActionResult GetAllPublishers()
        {
            _publisherService.GetAllPublishers();
            return Ok();    
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]

        public IActionResult GetPublisherData(int id) {
        
            var response = _publisherService.GetPublisherData(id);
            return Ok(response);
        }

        [HttpDelete("delete-publisher-by-id/{id}")]
        public IActionResult DeletePublisherData(int id) {

            _publisherService.DeletePublisherById(id);
            return Ok();
        }

    }
}
