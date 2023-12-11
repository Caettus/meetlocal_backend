using Microsoft.AspNetCore.Mvc;
using backend.application.Models;

namespace meetlocal_backendAPI.Controllers;

[Route("api/location")]
[ApiController]
public class LocationController : ControllerBase
{
    [HttpPost]
    public IActionResult PostLocation([FromBody] LocationModel locationModel)
    {
        if (locationModel == null)
        {
            return BadRequest("Invalid data");
        }

        try
        {
            Console.WriteLine(locationModel.Longtitude);
            Console.WriteLine(locationModel.Latitude);

            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

}