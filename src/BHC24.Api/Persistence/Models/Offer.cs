namespace BHC24.Api.Persistence.Models;

public class Offer : BaseTrackingEntity
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required Investor Investor { get; set; }
    public required Project Project { get; set; }
}