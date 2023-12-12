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

    
}