using System.Reflection;
using FluentValidation;
using Microsoft.OpenApi.Models;
using VatCalculator.Models;
using VatCalculator.Services;
using VatCalculator.Services.Interfaces;
using VatCalculator.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "VAT Calculator API",
        Version = "v1",
        Description = "An API to calculate VAT amounts for purchases in Austria.",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddScoped<IVatCalculatorService, VatCalculatorService>();
builder.Services.AddScoped<IValidator<VatCalculationRequestDto>, VatCalculationRequestValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "VAT Calculator API v1");
    });
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();