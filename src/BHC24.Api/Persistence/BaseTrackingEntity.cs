namespace BHC24.Api.Persistence;

public class BaseTrackingEntity : BaseEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}