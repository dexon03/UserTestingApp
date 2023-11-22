using System.Linq.Expressions;
using Moq;
using UserTestingAPI.Application.Services;
using UserTestingAPI.Core.Exceptions;
using UserTestingAPI.Core.Repository;
using UserTestingAPI.Domain.Dtos;
using UserTestingAPI.Domain.Entities;

namespace UnitTests;

public class TestServiceTests
{
    private readonly Mock<IRepository> _repositoryMock = new Mock<IRepository>();
    private readonly TestService _testService;
    
    public TestServiceTests()
    {
        _testService = new TestService(_repositoryMock.Object);
    }

    [Fact]
    public async Task GetAssignedTestsForUserAsync_WhenUserNotFound_ThrowsException()
    {
        // Arrange
        var userId = Guid.NewGuid();

        _repositoryMock.Setup(repo => repo.GetByIdAsync<User>(userId)).ReturnsAsync((User)null);
        

        // Act & Assert
        await Assert.ThrowsAsync<ExceptionWithStatusCode>(() => _testService.GetAssignedTestsForUserAsync(userId));
    }

    [Fact]
    public async Task GetTestByIdAsync_WhenUserExistsAndTestNotCompleted_ReturnsTestDto()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var testId = Guid.NewGuid();
        SetupMock(testId);
        

        // Act
        var result = await _testService.GetTestByIdAsync(userId, testId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<TestDto>(result);
    }
    
    private void SetupMock(Guid testId)
    {
        _repositoryMock.Setup(r => r.AnyAsync<User>(It.IsAny<Expression<Func<User, bool>>>())).ReturnsAsync(true);
        
        _repositoryMock.Setup(r => r.AnyAsync<UserTests>(It.IsAny<Expression<Func<UserTests, bool>>>())).ReturnsAsync(false);
        
        _repositoryMock.Setup(r => r.GetAll<Test>())
            .Returns(new List<Test> 
            { 
                new Test { Id = testId, Title = "Test title" } 
            }.AsQueryable());

        _repositoryMock.Setup(r => r.GetAll<Question>())
            .Returns(new List<Question> 
            { 
                new Question { Id = Guid.NewGuid(), Text = "Question text", TestId = testId } 
            }.AsQueryable());

        _repositoryMock.Setup(r => r.GetAll<Option>())
            .Returns(new List<Option> 
            { 
                new Option { Id = Guid.NewGuid(), Text = "Option text", QuestionId = Guid.NewGuid() } 
            }.AsQueryable());
    }

    [Fact]
    public async Task GetTestByIdAsync_WhenUserNotFound_ThrowsException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var testId = Guid.NewGuid();

        _repositoryMock.Setup(repo => repo.AnyAsync<User>(u => u.Id == userId)).ReturnsAsync(false);
        

        // Act & Assert
        await Assert.ThrowsAsync<ExceptionWithStatusCode>(() => _testService.GetTestByIdAsync(userId, testId));
    }

    [Fact]
    public async Task GetTestByIdAsync_WhenTestAlreadyCompletedOrNotAssigned_ThrowsException()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var testId = Guid.NewGuid();

        _repositoryMock.Setup(repo => repo.AnyAsync<User>(u => u.Id == userId)).ReturnsAsync(true);
        _repositoryMock.Setup(repo => repo.AnyAsync<UserTests>(ut => ut.UserId == userId && ut.TestId == testId && ut.Mark != null)).ReturnsAsync(true);


        // Act & Assert
        await Assert.ThrowsAsync<ExceptionWithStatusCode>(() => _testService.GetTestByIdAsync(userId, testId));
    }
}