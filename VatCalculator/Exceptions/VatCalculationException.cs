namespace VatCalculator.Exceptions;

/// <summary>
/// Represents errors that occur during VAT calculation.
/// </summary>
/// <remarks>
/// This exception is thrown when there is an issue with the VAT calculation logic or input validation.
/// </remarks>
public class VatCalculationException(string message, Exception innerException)
    : ArgumentException(message, innerException);