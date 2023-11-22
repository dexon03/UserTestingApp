using UserTestingAPI.Domain.Dtos;
using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Domain.Contracts;

public interface ITestCheckerService
{
    Task<UserTestDto> CheckAndAssignTestAsync(Guid testId, Guid userId, List<Guid> chosenOptions);
}