namespace UserTestingAPI.Domain.Dtos;

public record QuestionWithCorrectOption
{
    public Guid QuestionId { get; set; }
    public Guid CorrectOptionId { get; set; }
}