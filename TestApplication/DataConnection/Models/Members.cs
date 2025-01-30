namespace TestApplication.DataConnection.Models
{
    public class Members
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string email{ get; set; }
        public string phone {  get; set; }
        public List<BorrowRecord> BorrowRecords { get; set; } 
    }
}
