namespace UserTestingAPI.Domain.Dtos;

public record QuestionWithOptions
{
    public Guid? Id { get; set; }
    public string? Text { get; set; }
    public List<OptionDto>? Options { get; set; }
}