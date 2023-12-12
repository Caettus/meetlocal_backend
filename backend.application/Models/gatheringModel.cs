using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.application.Models;

public class gatheringModel
{
    [Key]
    public int GatheringId { get; set; }
    
    public string GatheringName { get; set; }
    
    public string GatheringDescription { get; set; }
    
    public string GatheringOrganiser { get; set; }

    [NotMapped]
    public string GatheringDate { get; set; }

    [NotMapped]
    public string GatheringTime { get; set; }

    public DateTime GatheringDateTime { get; set; }
    
    public string GatheringCategory { get; set; }

    public string GatheringLocation { get; set; }
}