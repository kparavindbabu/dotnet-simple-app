using Calculator.Service;
using Calculator.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorsController : ControllerBase
    {
        private readonly ICalculatorFactory _calculatorFactory;

        public CalculatorsController(
            ICalculatorFactory calculatorFactory)
        {
            _calculatorFactory = calculatorFactory;
        }

        [HttpGet]
        public IActionResult Get(
            [FromQuery] CalculatorOperation operation,
            [FromQuery] int firstOperand,
            [FromQuery] int secondOperand)
        {
            var calculatorService = _calculatorFactory.GetService(operation);

            return Ok(calculatorService.Calculate(firstOperand, secondOperand));
        }

    }
}
