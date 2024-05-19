using Calculator.Service.Implementations;

namespace CalculatorService.Tests
{
    public class MultiplyServiceTest
    {

        private readonly MultiplyService _service;

        public MultiplyServiceTest()
        {
            // Arrange
            _service = new MultiplyService();
        }

        [Theory]
        [InlineData(1, 1, 1)]
        [InlineData(1, 6, 6)]
        [InlineData(10, 6, 60)]
        [InlineData(-1, 1, -1)]
        [InlineData(-1, 5, -5)]
        public void Multiply_TwoNumbers_ShouldBeEqual(int a, int b, int expectedResult)
        {
            //Arrange


            //Act
            var result = _service.Calculate(a, b);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}