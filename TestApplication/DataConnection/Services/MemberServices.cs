using Microsoft.EntityFrameworkCore;
using TestApplication.DataConnection.Models;
using TestApplication.DataConnection.ViewModels;
using TestApplication.Migrations;

namespace TestApplication.DataConnection.Services
{
    public class MemberServices
    {
        private AppDbContext _context;

        public MemberServices(AppDbContext context)
        {
            _context = context;
        }

        public void AddMember(MembersVM members)
        {
            var _members = new Models.Members()
            {
                Name = members.Name,
                email = members.email,
                phone = members.phone,

            };
            _context.Members.Add(_members);
            _context.SaveChanges();
        }

        public void RemoveMemberByID(int memberId) {

            var _members = _context.Category.FirstOrDefault(n => n.Id == memberId);
            if (_members != null) {
                _context.Category.Remove(_members);
                _context.SaveChanges();
            }
        }

        public List<Models.Members> GetAllMembers() {
            return  _context.Members.ToList();
           
        }

        public Models.Members UpdateMemberById(int membersId, MembersVM member)
        {
            var _member = _context.Members.FirstOrDefault(n => n.Id == membersId);
            if (_member != null) {
                
                _member.Name = member.Name;
                _member.email = member.email;
                _member.phone = member.phone;
               

                _context.SaveChanges();
            }

            return _member;
        }


        //Borrow Book
        public BorrowRecord BorrowBook(int memberId, int bookId, DateTime borrowDate, DateTime returnDate)
        {
           
            var borrowRecord = new BorrowRecord
            {
                MemberId = memberId,
                BookId = bookId,
                BorrowDate = borrowDate,
                ReturnDate = returnDate 
            };

    
            _context.BorrowRecords.Add(borrowRecord);
            _context.SaveChanges();

            return borrowRecord; 
        }

        public List<BorrowRecord> GetAllBorrowedBooks()
        {
            // Fetch all borrow records where the return date is null or in the future
            var borrowedBooks = _context.BorrowRecords.ToList();

            return borrowedBooks;
        }

        public void DeleteBorrowRecord(int borrowRecordId)
        {
            // Find the borrow record by ID
            var borrowRecord = _context.BorrowRecords.FirstOrDefault(n => n.Id == borrowRecordId);
            if (borrowRecord != null)
            {
                _context.BorrowRecords.Remove(borrowRecord);
                _context.SaveChanges();
            }

        }



    }
}
