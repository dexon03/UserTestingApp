using UserTestingAPI.Domain.Dtos;
using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Domain.Contracts;

public interface ITestService
{
    Task<List<UserTestDto>> GetAssignedTestsForUserAsync(Guid userId);
    Task<TestDto> GetTestByIdAsync(Guid userId, Guid testId);
}