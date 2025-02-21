namespace VatCalculator.Models;

/// <summary>
/// Represents the response containing the calculated VAT amounts.
/// </summary>
public class VatCalculationResponseDto
{
    /// <summary>
    /// Gets or sets the net amount.
    /// </summary>
    /// <remarks>
    /// The net amount is the amount before VAT is applied.
    /// </remarks>
    public decimal NetAmount { get; set; }

    /// <summary>
    /// Gets or sets the gross amount.
    /// </summary>
    /// <remarks>
    /// The gross amount is the total amount including VAT.
    /// </remarks>
    public decimal GrossAmount { get; set; }

    /// <summary>
    /// Gets or sets the VAT amount.
    /// </summary>
    /// <remarks>
    /// The VAT amount is the calculated amount of VAT.
    /// </remarks>
    public decimal VatAmount { get; set; }
}