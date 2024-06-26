using backend.application.Mappers;
using backend.application.Models;
using backend.application.Repositories;
using MLDAL.Models;

namespace backend.application.Services;

public class gatheringService
{
    private readonly gatheringRepository _gatheringRepository;

    public gatheringService(gatheringRepository gatheringRepository)
    {
        _gatheringRepository = gatheringRepository;
    }

    public async Task<gatheringModel> AddGathering(gatheringModel gatheringModel)
    {
        return await _gatheringRepository.AddGathering(gatheringModel);
    }

    public async Task<gatheringModel> GetGathering(int id)
    {
        return await _gatheringRepository.GetGathering(id);
    }
    
    public async Task<List<gatheringModel>> GetGatherings(string search = "")
    {
        return await _gatheringRepository.GetGatherings(search);
    }

    public async Task<gatheringModel> DeleteGathering(int id)
    {
        return await _gatheringRepository.DeleteGathering(id);
    }
    
    
}