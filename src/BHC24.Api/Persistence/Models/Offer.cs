namespace BHC24.Api.Persistence.Models;

public class Offer : BaseTrackingEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ICollection<Tag>? Tags { get; set; }
    public required Project Project { get; set; }
}