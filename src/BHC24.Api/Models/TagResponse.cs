namespace BHC24.Api.Models;

public record TagResponse
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string ImagePath { get; init; }
}