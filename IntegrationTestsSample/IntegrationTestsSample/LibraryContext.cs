using IntegrationTestsSample.Models;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTestsSample
{
    public class LibraryContext: DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
    }
}
