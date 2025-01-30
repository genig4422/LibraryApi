﻿namespace TestApplication.DataConnection.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Book> Books { get; set; }
    }
}
