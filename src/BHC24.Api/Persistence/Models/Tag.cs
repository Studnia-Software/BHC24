namespace BHC24.Api.Persistence.Models;

public class Tag : BaseTrackingEntity
{
    public required string Name { get; set; }
    
    public virtual ICollection<Offer>? Offers { get; set; }
    public virtual ICollection<AppUser>? Users { get; set; }
}