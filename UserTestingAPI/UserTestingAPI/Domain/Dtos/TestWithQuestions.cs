using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Domain.Dtos;

public record TestWithQuestions
{
    public Guid TestId { get; set; }
    public string TestTitle { get; set; }
    public IEnumerable<QuestionWithCorrectOption> Questions { get; set; }
};