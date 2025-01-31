using Microsoft.AspNetCore.Mvc.Rendering;

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

    public class BookResponseVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ISBN { get; set; }
        public string PublisherName { get; set; }
      
        public List<string> AuthorNames { get; set; }
    }

    public class BookEditVM
    {
        public string Title { get; set; }
        public int ISBN { get; set; }
        public int PublisherId { get; set; }
     
        public string Publishers { get; set; }
        
        public string AuthorName { get; set; }
    }
}
