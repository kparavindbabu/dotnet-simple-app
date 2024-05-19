using Calculator.Service;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CalculatorApi.Tests
{
    public class EndpointTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;

        public EndpointTests(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();
        }

        [Theory]
        [InlineData(CalculatorOperation.Add, 1, 2, 3)]
        [InlineData(CalculatorOperation.Add, 1, -2, -1)]
        [InlineData(CalculatorOperation.Add, -1, -2, -3)]

        [InlineData(CalculatorOperation.Subtract, 1, 2, -1)]
        [InlineData(CalculatorOperation.Subtract, 1, -2, 3)]
        [InlineData(CalculatorOperation.Subtract, -1, -2, 1)]

        [InlineData(CalculatorOperation.Multiply, 1, 2, 2)]
        [InlineData(CalculatorOperation.Multiply, 1, -2, -2)]
        [InlineData(CalculatorOperation.Multiply, -1, -2, 2)]
        public async Task Get_Endpoint_ReturnsExpectedResponse(
            CalculatorOperation operation,
            int firstOperand,
            int secondOperand,
            int expected)
        {
            // Arrange

            // Act
            var response = await _client.GetAsync($"/api/calculators" +
                $"?operation={operation}&firstOperand={firstOperand}" +
                $"&secondOperand={secondOperand}");

            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.Equal(int.Parse(responseString), expected);
        }
    }

}