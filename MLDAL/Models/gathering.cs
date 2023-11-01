using System.ComponentModel.DataAnnotations;

namespace MLDAL.Models;

public class gathering
{
    [Key]
    public int GatheringId { get; set; }
    
    public string GatheringName { get; set; }
    
    public string GatheringDescription { get; set; }
    
    public string GatheringOrganiser { get; set; }
    
    public string GatheringDateTime { get; set; }
    
    public string GatheringCategory { get; set; }
}