using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationTestsSample.Tests
{
    public class InMemoryDatabaseWebApplicationFactory<T>: WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<LibraryContext>(options =>
                {
                    options.UseInMemoryDatabase("IntegrationTestsSampleInMemoryDb");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var builtServiceProvider = services.BuildServiceProvider();

                using (var scope = builtServiceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<LibraryContext>();
                    context.Database.EnsureCreated();
                    SeedData(context);
                }
            });
        }

        private void SeedData(LibraryContext context)
        {
            var firstBook = TestBooksCollection.GetDonChichot();

            var secondBook = TestBooksCollection.GetLittlePrince();

            context.Books.AddRange(firstBook, secondBook);
            context.SaveChanges();
        }
    }
}
