using FluentValidation;
using VatCalculator.Exceptions;
using VatCalculator.Models;
using VatCalculator.Services.Interfaces;
using VatCalculator.Validators;

namespace VatCalculator.Services;

/// <summary>
/// Provides methods for calculating VAT amounts based on the provided input.
/// </summary>
public class VatCalculatorService(IValidator<VatCalculationRequestDto> vatCalculationRequestValidator) : IVatCalculatorService
{
    /// <inheritdoc />
    public async Task<VatCalculationResponseDto> Calculate(VatCalculationRequestDto request)
    {
        var validationResult = await vatCalculationRequestValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var ex = new ValidationException(validationResult.Errors);
            throw new VatCalculationException(ex.Message, ex);
        }
        
        decimal netAmount, grossAmount, vatAmount;

        if (request.NetAmount.HasValue)
        {
            netAmount = request.NetAmount.Value;
            vatAmount = netAmount * request.VatRate / 100;
            grossAmount = netAmount + vatAmount;
        }
        else if (request.GrossAmount.HasValue)
        {
            grossAmount = request.GrossAmount.Value;
            netAmount = grossAmount / (1 + request.VatRate / 100);
            vatAmount = grossAmount - netAmount;
        }
        else
        {
            vatAmount = request.VatAmount.Value;
            netAmount = vatAmount / (request.VatRate / 100);
            grossAmount = netAmount + vatAmount;
        }

        return new VatCalculationResponseDto
        {
            NetAmount = netAmount,
            GrossAmount = grossAmount,
            VatAmount = vatAmount
        };
    }
}