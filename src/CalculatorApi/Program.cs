using Calculator.Service;
using Calculator.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Register();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapGet("/CalculatorMap", (
    ICalculatorFactory calculatorFactory,
    [FromQuery] CalculatorOperation operation,
    [FromQuery] int firstOperand,
    [FromQuery] int secondOperand) =>
{
    var calculatorService = calculatorFactory.GetService(operation);

    return calculatorService.Calculate(firstOperand, secondOperand);
})
.WithName("GetCalculator")
.WithOpenApi();

app.Run();

// for integration tests
public partial class Program { }
