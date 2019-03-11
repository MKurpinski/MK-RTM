using System;
using System.Collections.Generic;
using System.Text;
using IntegrationTestsSample.Models;

namespace IntegrationTestsSample.Tests
{
    public static class TestBooksCollection
    {
        public static Book GetLittlePrince()
        {
            return new Book
            {
                Id = 1,
                Isbn = "fwsrtyuiopasn",
                Title = "The Little Prince"
            };
        }
        public static Book GetDonChichot()
        {
            return new Book
            {
                Id = 2,
                Isbn = "qwertyuiopasd",
                Title = "Don Chichot"
            };
        }
    }
}
