namespace BHC24.Api.TempStorage;

public class CommitListStorage
{
    public IEnumerable<CommitResponseDto> Commits { get; set; } = [];
}