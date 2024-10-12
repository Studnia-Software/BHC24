using BHC24.Api.Persistence.Models;

namespace BHC24.Api.Models.Offer;

public class GetOfferResponse
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    
    public ICollection<AppUser> Collaborators { get; set; } = [];

    public ICollection<Tag>? Tags { get; set; }
    public required Project Project { get; set; }
}