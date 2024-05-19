using Calculator.Service.Contracts;

namespace Calculator.Service.Implementations;

public abstract class BaseCalculatorService : ICalculatorOperation
{
    public abstract CalculatorOperation Operation { get; }

    public abstract int Calculate(int a, int b);
}
