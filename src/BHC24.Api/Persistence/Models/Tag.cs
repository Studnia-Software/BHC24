namespace BHC24.Api.Persistence.Models;

public class Tag : BaseTrackingEntity
{
    public required string Name { get; set; }
    
    public ICollection<Offer>? Offers { get; set; }
    public ICollection<AppUser>? Users { get; set; }
    public ICollection<Project>? Projects { get; set; }
}