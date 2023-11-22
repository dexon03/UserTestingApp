using Newtonsoft.Json;

namespace UserTestingAPI.Domain.Entities;

public class Test
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    [JsonIgnore]public ICollection<Question> Questions { get; set; }
    [JsonIgnore]public ICollection<UserTests> CompletedTests { get; set; }
}