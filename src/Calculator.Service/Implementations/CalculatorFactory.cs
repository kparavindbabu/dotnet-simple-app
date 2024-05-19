using Calculator.Service.Contracts;

namespace Calculator.Service.Implementations
{
    internal class CalculatorFactory : ICalculatorFactory
    {
        private readonly IEnumerable<ICalculatorOperation> _calculatorOperations;

        public CalculatorFactory(
            IEnumerable<ICalculatorOperation> calculatorOperations)
        {
            _calculatorOperations = calculatorOperations;
        }

        public ICalculatorOperation GetService(CalculatorOperation operation)
        {
            return _calculatorOperations.Single(x => x.Operation == operation);
        }
    }
}
