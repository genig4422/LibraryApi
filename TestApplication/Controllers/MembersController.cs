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
    public class MembersController : ControllerBase
    {
        public MemberServices _memberService;

        public MembersController(MemberServices membersService)
        {
            _memberService = membersService;
        }

        [HttpPost("add-member")]
        public IActionResult AddMember([FromBody] MembersVM member)
        {
            _memberService.AddMember(member);
            return Ok(member);

        }

        [HttpGet("show-all-members")]
        public IActionResult GetAllMembers()
        {
            var members = _memberService.GetAllMembers();
            return Ok(members);
        }

        [HttpDelete("remove-member-by-id/{id}")]
        public IActionResult RemoveMemberById(int id)
        {
            _memberService.RemoveMemberByID(id);
            return Ok();
        }

        [HttpPut("update-member-by-id/{id}")]
        public IActionResult UpdateMemberById(int id, [FromBody] MembersVM members)
        {
            _memberService.UpdateMemberById(id, members);
            return Ok();
        }

        [HttpPost("borrow-book")]
        public IActionResult BorrowBook(int memberId, int bookId, DateTime returnDate)
        {
            var borrowDate = DateTime.Now; // Set the borrow date to the current date

            // Attempt to borrow the book
            var borrowRecord = _memberService.BorrowBook(memberId, bookId, borrowDate, returnDate);

            return Ok(borrowRecord);
        }

        [HttpGet("all-borrowed-books")]
        public IActionResult GetAllBorrowedBooks()
        {
            var borrowers = _memberService.GetAllBorrowedBooks();
            return Ok(borrowers);
        }

        [HttpDelete("delete-borrowed-by-id/{id}")]
        public IActionResult DeleteBorrowRecord(int id) { 
            
            _memberService.DeleteBorrowRecord(id);
            return Ok();
        }
    }
}
