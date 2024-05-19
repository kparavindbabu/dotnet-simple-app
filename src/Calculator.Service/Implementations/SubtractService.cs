namespace Calculator.Service.Implementations
{
    public class SubtractService : BaseCalculatorService
    {
        public override CalculatorOperation Operation => CalculatorOperation.Subtract;

        public override int Calculate(int a, int b)
        {
            return a - b;
        }

    }
}
