using IntegrationTestsSample.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace IntegrationTestsSample.Tests.Controllers
{
    public class BookControllerTests : IClassFixture<InMemoryDatabaseWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private const string API_BASE = "/api/books";

        public BookControllerTests(InMemoryDatabaseWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenGetBooks_ShouldReturnCorrectCollectionOfBooks()
        {
            // Act
            var httpResponse = await _client.GetAsync(API_BASE);
            httpResponse.EnsureSuccessStatusCode();
            var responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // Assert
            var books = JsonConvert.DeserializeObject<IEnumerable<Book>>(responseAsString);
            books.Should().NotBeNull();
            books.Should().HaveCount(2);
            books.Should().BeEquivalentTo(TestBooksCollection.GetLittlePrince(), TestBooksCollection.GetDonChichot());
        }

        [Fact]
        public async Task GivenGetByIsbn_WhenBookWithProvidedIsbnExists_ShouldReturnBook()
        {
            // Arrange
            var expected = TestBooksCollection.GetLittlePrince();

            // Act
            var httpResponse = await _client.GetAsync($"{API_BASE}/{expected.Isbn}");
            httpResponse.EnsureSuccessStatusCode();
            var responseAsString = await httpResponse.Content.ReadAsStringAsync();

            // Assert
            var books = JsonConvert.DeserializeObject<Book>(responseAsString);
            books.Should().NotBeNull();
            books.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public async Task GivenGetByIsbn_WhenBookWithProvidedIsbnDoesNotExist_ShouldReturnNotFoundStatusCode()
        {
            // Arrange
            const string notExistingIsbn = "1234567891012";

            // Act
            var httpResponse = await _client.GetAsync($"{API_BASE}/{notExistingIsbn}");

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GivenGetByIsbn_WhenIsbnIsNotCorrect_ShouldReturnBadRequestStatusCode()
        {
            // Arrange
            const string incorrectIsbn = "dasffa";

            // Act
            var httpResponse = await _client.GetAsync($"{API_BASE}/{incorrectIsbn}");

            // Assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
