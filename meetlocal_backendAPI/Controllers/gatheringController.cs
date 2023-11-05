﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLDAL;
using MLDAL.Models;



[Route("api/[controller]")]
[ApiController]
public class gatheringController : ControllerBase
{
    private readonly AppDbContext _context;

    public gatheringController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/gathering
    [HttpGet]
    public async Task<ActionResult<IEnumerable<gathering>>> GetGatherings()
    {
        return await _context.Gatherings.ToListAsync();
    }

    // GET: api/gathering/5
    [HttpGet("{id}")]
    public async Task<ActionResult<gathering>> GetGathering(int id)
    {
        var gathering = await _context.Gatherings.FindAsync(id);

        if (gathering == null)
        {
            return NotFound();
        }

        return gathering;
    }

    // POST: api/gathering
    [HttpPost]
    public async Task<ActionResult<gathering>> PostGathering(gathering gathering)
    {
        _context.Gatherings.Add(gathering);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetGathering", new { id = gathering.GatheringId }, gathering);
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
