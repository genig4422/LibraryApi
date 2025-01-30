using System.Globalization;

namespace TestApplication.DataConnection.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int ISBN { get; set; }

        //Navigation Properties

        public int? PublisherId {  get; set; }
        public Publisher? Publisher{get; set;}

        public int? CategoryId { get; set; }

        public Category? Category{get; set; }
        
        //Navigation Properties
        public List<Book_Author> Book_Authors { get; set; }

        public List<BorrowRecord> BorrowRecords { get; set; }
    }
}
