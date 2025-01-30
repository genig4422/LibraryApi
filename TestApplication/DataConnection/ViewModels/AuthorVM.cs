namespace TestApplication.DataConnection.ViewModels
{
    public class AuthorVM
    {
        public string Name { get; set; }
    }

    public class AuthorWithBooksVM
    {
        public string Name { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
