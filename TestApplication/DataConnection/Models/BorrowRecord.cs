using System.Text.Json.Serialization;

namespace TestApplication.DataConnection.Models
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        public int BookId { get; set; }
 
        public Book Book { get; set; }
        public int MemberId { get; set; }
        public Members Member { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
