using meetlocal_backendAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

        // Your data validation logic here

        try
        {
            Console.WriteLine(locationModel.Longtitude);
            Console.WriteLine(locationModel.Latitude);

            return Ok();
        }
        catch (Exception ex)
        {
            // Log the error
            Console.WriteLine(ex);
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

}