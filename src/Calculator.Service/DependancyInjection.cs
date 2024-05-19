using Calculator.Service.Contracts;
using Calculator.Service.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Service
{
    public static class DependancyInjection
    {
        public static void Register(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICalculatorOperation, AdditionService>();
            serviceCollection.AddScoped<ICalculatorOperation, SubtractService>();
            serviceCollection.AddScoped<ICalculatorOperation, MultiplyService>();

            serviceCollection.AddScoped<ICalculatorFactory, CalculatorFactory>();
        }
    }
}
