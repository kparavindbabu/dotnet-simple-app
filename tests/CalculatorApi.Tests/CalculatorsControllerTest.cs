using Calculator.Service;
using Calculator.Service.Contracts;
using CalculatorApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace CalculatorApi.Tests;

public class CalculatorsControllerTest
{

    private static CalculatorsController SetupMock(
        CalculatorOperation calculatorOperation,
        int a, int b,
        int expected)
    {
        var operationMock = Substitute.For<ICalculatorOperation>();
        operationMock.Operation.Returns(calculatorOperation);
        operationMock.Calculate(a, b).Returns(expected);

        var factoryMock = Substitute.For<ICalculatorFactory>();
        factoryMock.GetService(calculatorOperation).Returns(operationMock);

        return new CalculatorsController(factoryMock);
    }

    [Theory]
    [InlineData(CalculatorOperation.Add, 1, 2, 3)]
    [InlineData(CalculatorOperation.Add, 1, -2, -1)]
    [InlineData(CalculatorOperation.Add, -1, -2, -1)]

    [InlineData(CalculatorOperation.Subtract, 1, 2, -1)]
    [InlineData(CalculatorOperation.Subtract, 1, -2, 3)]
    [InlineData(CalculatorOperation.Subtract, -1, -2, 1)]
    public void Calculate_Operation_ShouldMatch(
        CalculatorOperation calculatorOperation,
        int firstOperand, int secondOperand,
        int expected)
    {
        // Arrange
        var calculatorController = SetupMock(
            calculatorOperation,
            firstOperand,
            secondOperand,
            expected);

        // Act
        var result = calculatorController.Get(
            calculatorOperation,
            firstOperand,
            secondOperand) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);

        var responseString = result.Value?.ToString();

        Assert.Equal(int.Parse(responseString), expected);
    }
}