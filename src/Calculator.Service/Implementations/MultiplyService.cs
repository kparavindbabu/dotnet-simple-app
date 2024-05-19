namespace Calculator.Service.Implementations
{
    public class MultiplyService : BaseCalculatorService
    {
        public override CalculatorOperation Operation => CalculatorOperation.Multiply;

        public override int Calculate(int a, int b)
        {
            return a * b;
        }
    }

}
