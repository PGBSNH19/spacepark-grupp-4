using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace SpacePark.Tests
{
    public class Return200StatusCode : IClassFixture<WebApplicationFactory<SpacePark.API.Startup>>
    {
        private readonly WebApplicationFactory<SpacePark.API.Startup> _factory;

        public Return200StatusCode(WebApplicationFactory<SpacePark.API.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async void ReturnValid200StatusCode()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("https://spaceparkbackendgroup4.azurewebsites.net/API/v1.0/ParkingLot/Check");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
}
