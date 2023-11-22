using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserTestingAPI.Domain.Contracts;

namespace UserTestingAPI.Controllers;

[Authorize]
public class TestController : BaseController
{
    private readonly ITestService _testService;

    public TestController(ITestService testService)
    {
        _testService = testService;
    }

    [HttpGet("assignedTests/{userId}")]
    public async Task<IActionResult> GetCompletedTests(Guid userId)
    {
        var result = await _testService.GetAssignedTestsForUserAsync(userId);
        return Ok(result);
    }
    
    [HttpGet("{userId}/{testId}")]
    public async Task<IActionResult> GetTest(Guid userId,Guid testId)
    {
        var result = await _testService.GetTestByIdAsync(userId, testId);
        return Ok(result);
    }
}