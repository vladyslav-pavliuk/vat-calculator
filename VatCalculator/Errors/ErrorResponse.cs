namespace VatCalculator.Errors;

/// <summary>
/// Represents an error response returned by the API.
/// </summary>
/// <remarks>
/// This class is used to standardize error responses in the API.
/// </remarks>
public class ErrorResponse(string error)
{
    /// <summary>
    /// Gets or sets the error message.
    /// </summary>
    /// <remarks>
    /// This property contains a description of the error that occurred.
    /// </remarks>
    public string Error { get; set; } = error;
}