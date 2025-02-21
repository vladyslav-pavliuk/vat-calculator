namespace VatCalculator.Models;

/// <summary>
/// Represents a request for VAT calculation.
/// </summary>
public class VatCalculationRequestDto
{
    /// <summary>
    /// Gets or sets the net amount (optional).
    /// </summary>
    /// <remarks>
    /// The net amount is the amount before VAT is applied.
    /// </remarks>
    public decimal? NetAmount { get; set; }

    /// <summary>
    /// Gets or sets the gross amount (optional).
    /// </summary>
    /// <remarks>
    /// The gross amount is the total amount including VAT.
    /// </remarks>
    public decimal? GrossAmount { get; set; }

    /// <summary>
    /// Gets or sets the VAT amount (optional).
    /// </summary>
    /// <remarks>
    /// The VAT amount is the amount of VAT to be calculated.
    /// </remarks>
    public decimal? VatAmount { get; set; }

    /// <summary>
    /// Gets or sets the VAT rate (required).
    /// </summary>
    /// <remarks>
    /// The VAT rate must be 10%, 13%, or 20%.
    /// </remarks>
    public decimal VatRate { get; set; }
}