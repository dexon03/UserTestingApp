namespace UserTestingAPI.Domain.Dtos;

public record UserTestDto
{
    public Guid TestId { get; set; }
    public string TestTitle { get; set; }
    public int? Mark { get; set; }
    public DateTime? CompletionDate { get; set; }
};