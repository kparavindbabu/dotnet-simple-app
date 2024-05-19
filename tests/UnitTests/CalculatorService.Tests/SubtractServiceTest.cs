using Calculator.Service.Implementations;

namespace CalculatorService.Tests
{
    public class SubtractServiceTest
    {

        private readonly SubtractService _service;

        public SubtractServiceTest()
        {
            // Arrange
            _service = new SubtractService();
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(1, 6, -5)]
        [InlineData(10, 6, 4)]
        [InlineData(-1, 1, -2)]
        [InlineData(-1, 5, -6)]
        public void Subtract_TwoNumbers_ShouldBeEqual(int a, int b, int expectedResult)
        {
            //Arrange


            //Act
            var result = _service.Calculate(a, b);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}