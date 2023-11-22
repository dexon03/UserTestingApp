namespace UserTestingAPI.Domain.Dtos;

public record OptionDto
{
    public Guid? Id { get; set; }
    public string? Text { get; set; }
};