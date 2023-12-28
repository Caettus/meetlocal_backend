using System.Globalization;
using backend.application.Mappers;
using backend.application.Models;
using Microsoft.EntityFrameworkCore;
using MLDAL;
using MLDAL.Models;

namespace backend.application.Repositories;

public class gatheringRepository
{
    private readonly AppDbContext _context;
    
    public gatheringRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<gatheringModel> AddGathering(gatheringModel gatheringModel)
    {
        gatheringModel.GatheringDateTime = DateTime.SpecifyKind(
            DateTime.ParseExact($"{gatheringModel.GatheringDate} {gatheringModel.GatheringTime}", "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture),
            DateTimeKind.Utc
        );
        var gathering = gatheringMapper.toDataModel(gatheringModel);
        await _context.Gatherings.AddAsync(gathering);
        await _context.SaveChangesAsync();
        return gatheringModel;
    }

    public async Task<gatheringModel> GetGathering(int id)
    {
        var gathering = gatheringMapper.toLogicModel(await _context.Gatherings.FindAsync(id));

        if (gathering == null)
        {
            throw new Exception("Gathering not found");
        }

        return gathering;
    }
    
    public async Task<List<gatheringModel>> GetGatherings(string search = "")
    {
        var gatherings = _context.Gatherings.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            gatherings = gatherings.Where(g => g.GatheringName.Contains(search) || g.GatheringDescription.Contains(search));
        }
        else
        {
            throw new Exception("No gatherings found");
            
        }

        return await gatherings.Select(g => gatheringMapper.toLogicModel(g)).ToListAsync();
    }


    
    public async Task<gatheringModel> DeleteGathering(int id)
    {
        var gathering = await _context.Gatherings.FindAsync(id);
        if (gathering == null)
        {
            throw new Exception("Gathering not found");
        }
        _context.Gatherings.Remove(gathering);
        await _context.SaveChangesAsync();
        return gatheringMapper.toLogicModel(gathering);
    }
}