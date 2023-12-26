using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLDAL;
using MLDAL.Models;
using backend.application.Models;
using backend.application.Mappers;
using backend.application.Repositories;
using backend.application.Services;


[Route("api/[controller]")]
[ApiController]
public class gatheringController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly gatheringService _gatheringService;
    

    public gatheringController(AppDbContext context, gatheringService gatheringService)
    {
        _context = context;
        _gatheringService = gatheringService;
    }

    // GET: api/gathering
    [HttpGet]
    public async Task<ActionResult<IEnumerable<gathering>>> GetGatherings(string search = "")
    {
        try
        {
            var gatherings = await _gatheringService.GetGatherings(search);
            return Ok(gatherings);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }



    // GET: api/gathering/5
    [HttpGet("{id}")]
    public async Task<ActionResult<gathering>> GetGathering(int id)
    {
        try
        {
            var gathering = await _gatheringService.GetGathering(id);
            return Ok(gathering);
        }
        catch (Exception ex)
        {
            if (ex.Message == "Gathering not found")
            {
                return NotFound();
            }

            return StatusCode(500, "An error occurred while processing your request.");
        }
    }


    // POST: api/gathering
    [HttpPost]
    public async Task<ActionResult<gathering>> PostGathering(gatheringModel model)
    {
        try
        {
            var result = await _gatheringService.AddGathering(model);

            return CreatedAtAction("GetGathering", new { id = model.GatheringId }, model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal Server Error: {ex.Message}");
        }
    }



    // DELETE: api/gathering/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGathering(int id)
    {
        try
        {
            var result = await _gatheringService.DeleteGathering(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            if (e.Message == "Gathering not found")
            {
                return NotFound();
            }

            return StatusCode(500, "An error occurred while processing your request.");
        }
    
    }

    private bool GatheringExists(int id)
    {
        return _context.Gatherings.Any(e => e.GatheringId == id);
    }
}
