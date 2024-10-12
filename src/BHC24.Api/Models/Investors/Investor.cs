using BHC24.Api.Models.Projects;

namespace BHC24.Api.Models.Investors;

public class GetInvestorResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Email { get; init; }
    public string PhoneNumber { get; init; }
    public string? CompanyName { get; init; }
    public bool HasPremium { get; set; } = false;
    
}

public record AddInvestorRequest(string Name, string Surname, string Email, string PhoneNumber, string? CompanyName);
