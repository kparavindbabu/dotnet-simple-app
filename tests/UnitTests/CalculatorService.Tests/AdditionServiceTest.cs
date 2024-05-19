using Calculator.Service.Implementations;

namespace CalculatorService.Tests
{
    public class AdditionServiceTest
    {

        private readonly AdditionService _service;

        public AdditionServiceTest()
        {
            // Arrange
            _service = new AdditionService();
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(-1, 1, 0)]
        [InlineData(-1, 5, 4)]
        public void Add_TwoNumbers_ShouldBeEqual(int a, int b, int expectedResult)
        {
            //Arrange


            //Act
            var result = _service.Calculate(a, b);

            //Assert
            Assert.Equal(expectedResult, result);
        }
    }
}