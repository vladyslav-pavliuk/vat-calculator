namespace VatCalculator.Constants;

/// <summary>
///     Route prefixes for controllers.
/// </summary>
public static class RoutePaths
{
    /// <summary>The base controller route.</summary>
    private const string Api = "api/";

    #region Calculation management controllers

    /// <summary>The  route path of VAT calculations.</summary>
    public const string Vat = Api + "vat";

    #endregion
}