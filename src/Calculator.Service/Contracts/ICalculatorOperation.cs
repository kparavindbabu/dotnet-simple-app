namespace Calculator.Service.Contracts;

public interface ICalculatorOperation
{
    CalculatorOperation Operation { get; }

    int Calculate(int a, int b);
}
