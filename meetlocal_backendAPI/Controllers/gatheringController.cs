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
        var gatherings = _context.Gatherings.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            gatherings = gatherings.Where(g => g.GatheringName.Contains(search) || g.GatheringDescription.Contains(search));
        }

        return await gatherings.ToListAsync();
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



    // PUT: api/gathering/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutGathering(int id, gathering gathering)
    {
        if (id != gathering.GatheringId)
        {
            return BadRequest();
        }

        _context.Entry(gathering).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!GatheringExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/gathering/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGathering(int id)
    {
        var gathering = await _context.Gatherings.FindAsync(id);
        if (gathering == null)
        {
            return NotFound();
        }

        _context.Gatherings.Remove(gathering);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool GatheringExists(int id)
    {
        return _context.Gatherings.Any(e => e.GatheringId == id);
    }
}
