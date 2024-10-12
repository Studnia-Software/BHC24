using System.Reflection.Metadata.Ecma335;

namespace BHC24.Api.Persistence.Models;

public class Offer : BaseTrackingEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;

    public ICollection<Tag>? Tags { get; set; }
    
    public required int ProjectId { get; set; }
    public Project? Project { get; set; }
}