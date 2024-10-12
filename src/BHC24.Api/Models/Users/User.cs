
namespace BHC24.Api.Models.Users;

public class GetUserResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public Persistence.Models.Profile Profile { get; set; }
}