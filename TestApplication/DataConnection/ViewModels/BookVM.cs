namespace TestApplication.DataConnection.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int PublisherId{ get; set; }
        public List<int> AuthorIds { get; set; }

    }

    public class BookWithAuthorsVM
    {
        public string Title { get; set; }
        public int ISBN { get; set; }
        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }

    }
}
