namespace UserTestingAPI.Domain.Dtos;

public record TestDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public IEnumerable<QuestionWithOptions>? Questions { get; init; }
};