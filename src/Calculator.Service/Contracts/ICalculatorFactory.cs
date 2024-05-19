namespace Calculator.Service.Contracts
{
    public interface ICalculatorFactory
    {
        ICalculatorOperation GetService(CalculatorOperation operation);
    }
}