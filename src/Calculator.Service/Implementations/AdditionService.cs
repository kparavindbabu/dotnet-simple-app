namespace Calculator.Service.Implementations;

public class AdditionService : BaseCalculatorService
{
    public override CalculatorOperation Operation => CalculatorOperation.Add;

    public override int Calculate(int a, int b)
    {
        return a + b;
    }

}
