namespace UserTestingAPI.Domain.Entities;

public class Question
{
    public Guid Id { get; set; }
    public string Text { get; set; }
    public Guid TestId { get; set; }
    public Guid CorrectOptionId { get; set; }
    
    public Test Test { get; set; }
    public ICollection<Option> Options { get; set; }
}