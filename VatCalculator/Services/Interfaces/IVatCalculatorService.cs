using VatCalculator.Models;

namespace VatCalculator.Services.Interfaces;

/// <summary>
/// Provides methods for calculating VAT amounts based on the provided input.
/// </summary>
public interface IVatCalculatorService
{
    /// <summary>
    /// Calculates the Net, Gross, and VAT amounts based on the provided input.
    /// </summary>
    /// <param name="requestDto">The request containing the input amounts and VAT rate.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation. The task result contains the
    /// <see cref="VatCalculationResponseDto"/> with the calculated amounts.
    /// </returns>
    /// <exception cref="VatCalculationException">
    /// Thrown when the calculation fails due to invalid input or business logic errors.
    /// </exception>
    Task<VatCalculationResponseDto> Calculate(VatCalculationRequestDto requestDto);
}