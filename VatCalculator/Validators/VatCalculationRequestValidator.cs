using FluentValidation;
using VatCalculator.Models;

namespace VatCalculator.Validators;

/// <summary>
/// Validates the <see cref="VatCalculationRequestDto"/> to ensure it meets the requirements for VAT calculation.
/// </summary>
public class VatCalculationRequestValidator : AbstractValidator<VatCalculationRequestDto>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VatCalculationRequestValidator"/> class.
    /// </summary>
    public VatCalculationRequestValidator()
    {
        RuleFor(x => x.VatRate)
            .NotEmpty()
            .WithMessage("VAT rate is required.")
            .Must(BeAValidVatRate)
            .WithMessage("VAT rate must be 10%, 13%, or 20%.");

        RuleFor(x => x)
            .Must(HasExactlyOneInput)
            .WithMessage("Provide exactly one of NetAmount, GrossAmount, or VatAmount.");

        RuleFor(x => x.NetAmount)
            .GreaterThan(0)
            .When(x => x.NetAmount.HasValue)
            .WithMessage("NetAmount must be greater than 0.");

        RuleFor(x => x.GrossAmount)
            .GreaterThan(0)
            .When(x => x.GrossAmount.HasValue)
            .WithMessage("GrossAmount must be greater than 0.");

        RuleFor(x => x.VatAmount)
            .GreaterThan(0)
            .When(x => x.VatAmount.HasValue)
            .WithMessage("VatAmount must be greater than 0.");
    }

    private static bool BeAValidVatRate(decimal vatRate)
    {
        return vatRate is 10 or 13 or 20;
    }
    
    private static bool HasExactlyOneInput(VatCalculationRequestDto request)
    {
        var inputCount = 0;
        if (request.NetAmount.HasValue) inputCount++;
        if (request.GrossAmount.HasValue) inputCount++;
        if (request.VatAmount.HasValue) inputCount++;
        return inputCount == 1;
    }
}