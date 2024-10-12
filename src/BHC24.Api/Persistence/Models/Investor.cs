namespace BHC24.Api.Persistence.Models;

public class Investor : BaseTrackingEntity
{
    public required string Name { get; set; }
    public required string Surname { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public bool HasPremium { get; set; }
}