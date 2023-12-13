namespace backend.application.Mappers;
using backend.application.Models;
using MLDAL.Models;

public class gatheringMapper
{
    public static gatheringModel? toLogicModel(gathering? gathering)
    {
        if (gathering == null)
        {
            return null;
        }
        return new gatheringModel
        {
            GatheringId = gathering.GatheringId,
            GatheringName = gathering.GatheringName,
            GatheringDescription = gathering.GatheringDescription,
            GatheringOrganiser = gathering.GatheringOrganiser,
            GatheringDateTime = gathering.GatheringDateTime,
            GatheringCategory = gathering.GatheringCategory,
            GatheringLocation = gathering.GatheringLocation
        };
    }
    
    public static gathering? toDataModel(gatheringModel? gatheringModel)
    {
        if (gatheringModel == null)
        {
            return null;
        }
        return new gathering
        {
            GatheringId = gatheringModel.GatheringId,
            GatheringName = gatheringModel.GatheringName,
            GatheringDescription = gatheringModel.GatheringDescription,
            GatheringOrganiser = gatheringModel.GatheringOrganiser,
            GatheringDateTime = gatheringModel.GatheringDateTime,
            GatheringCategory = gatheringModel.GatheringCategory,
            GatheringLocation = gatheringModel.GatheringLocation
        };
    }
}