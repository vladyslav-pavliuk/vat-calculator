using System.Net;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using VatCalculator.Constants;
using VatCalculator.Errors;
using VatCalculator.Exceptions;
using VatCalculator.Models;
using VatCalculator.Services.Interfaces;

namespace VatCalculator.Controllers;

/// <summary>
/// Controller for handling VAT calculation requests.
/// </summary>
[ApiController]
[Route(RoutePaths.Vat)]
public class VatController(IVatCalculatorService vatCalculatorService, ILogger<VatController> logger) : ControllerBase
{
    /// <summary>
    /// Calculates the Net, Gross, and VAT amounts based on the provided input.
    /// </summary>
    /// <param name="requestDto">The request containing the input amounts and VAT rate.</param>
    /// <returns>
    /// A <see cref="VatCalculationResponseDto"/> with the calculated amounts if successful.
    /// Otherwise, returns an <see cref="ErrorResponse"/> with the error details.
    /// </returns>
    /// <response code="200">Returns the calculated VAT amounts.</response>
    /// <response code="400">Returns an error message if the request is invalid.</response>
    [HttpPost]
    [ProducesResponseType(typeof(VatCalculationResponseDto), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ErrorResponse), (int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> Calculate([FromBody] VatCalculationRequestDto requestDto)
    {
        logger.LogInformation("Received VAT calculation request: {@Request}", requestDto);

        try
        {
            var result = await vatCalculatorService.Calculate(requestDto);
            logger.LogInformation("VAT calculation successful. Result: {@Result}", result);
            return Ok(result);
        }
        catch (VatCalculationException ex)
        {
            logger.LogError(ex, "VAT calculation failed: {Message}", ex.Message);

            if (ex.InnerException is not ValidationException validationException)
                return BadRequest(new ErrorResponse(ex.Message));
            logger.LogError("Validation errors: {@Errors}", validationException.Errors);

            return BadRequest(new ErrorResponse(string.Join(" ", validationException.Errors)));
        }
    }
}