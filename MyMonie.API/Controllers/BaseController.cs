using System.Net;
using Microsoft.AspNetCore.Mvc;
using MyMonie.Core.Models.Utilities;

namespace MyMonie.API.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    /// <summary>
    /// Returns the appropriate HTTP Response.
    /// </summary>
    /// <param name="result">The result.</param>
    /// <returns></returns>
    protected IActionResult ProcessResponse(Result result)
    {
        if (result.Success)
        {
            return Ok(result);
        }
        else if (result.Status == 401)
        {
            return Unauthorized(result);
        }
        else if (result.Status == 403)
        {
            return StatusCode((int)HttpStatusCode.Forbidden, result);
        }
        else if (result.Status == 404)
        {
            return NotFound(result);
        }
        else if (result.Status == 500)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, result);
        }
        else
        {
            return StatusCode((int)HttpStatusCode.BadRequest, result);
        }
    }
}