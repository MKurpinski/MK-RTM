using System;
using System.ComponentModel.DataAnnotations;

namespace IntegrationTestsSample.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
    }
}
