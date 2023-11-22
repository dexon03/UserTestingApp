using UserTestingAPI.Domain.Dtos;

namespace UserTestingAPI.Domain.Entities;

public class UserTests
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid TestId { get; set; }
    public int? Mark { get; set; }
    
    public DateTime? CompletionDate { get; set; }

    public User User { get; set; }
    public Test Test { get; set; }
}


internal static class UserTestExtension
{
    internal static UserTestDto ToDto(this UserTests userTest, string testTitle)
    {
        return new UserTestDto
        {
            TestId = userTest.TestId,
            Mark = userTest.Mark,
            CompletionDate = userTest.CompletionDate,
            TestTitle = testTitle
        };
    }
}