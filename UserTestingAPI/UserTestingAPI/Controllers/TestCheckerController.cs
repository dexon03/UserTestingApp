using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTestingAPI.Domain.Contracts;

namespace UserTestingAPI.Controllers;

[Authorize]
public class TestCheckerController : BaseController
{
    private readonly ITestCheckerService _testCheckerService;

    public TestCheckerController(ITestCheckerService testCheckerService)
    {
        _testCheckerService = testCheckerService;
    }
    
    [HttpPost("{testId}/{userId}")]
    public async Task<IActionResult> CheckTest(Guid testId, Guid userId, List<Guid> chosenOptions)
    {
        var result = await _testCheckerService.CheckAndAssignTestAsync(testId, userId, chosenOptions);
        return Ok(result);
    }
}