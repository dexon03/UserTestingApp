using Moq;
using UserTestingAPI.Application.Services;
using UserTestingAPI.Core.Repository;
using UserTestingAPI.Domain.Dtos;
using UserTestingAPI.Domain.Entities;

namespace UnitTests;

public class TestCheckerServiceTest
{
    private readonly Mock<IRepository> _repositoryMock = new Mock<IRepository>();
    private readonly TestCheckerService _testService;
    
    public TestCheckerServiceTest()
    {
        _testService = new TestCheckerService(_repositoryMock.Object);
    }
    
    [Fact]
    public async Task CheckAndAssignTestAsync_ShouldAssignTest_WhenTestExists()
    {
        // Arrange
        var testId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var chosenOptions = new List<Guid> { Guid.NewGuid() };

        var testWithQuestions = new TestWithQuestions
        {
            TestId = testId,
            TestTitle = "Test title",
            Questions = new List<QuestionWithCorrectOption>
            {
                new QuestionWithCorrectOption
                {
                    QuestionId = Guid.NewGuid(),
                    CorrectOptionId = chosenOptions.First(),
                },
            },
        };
    

        _repositoryMock.Setup(repo => repo.GetAll<Test>()).Returns(new List<Test>() {new Test { Id = testId }}.AsQueryable());
        _repositoryMock.Setup(repo => repo.GetAll<Question>()).Returns(new List<Question> { new Question{Id = Guid.NewGuid(), TestId = testId, CorrectOptionId = chosenOptions.First() }}.AsQueryable());
        

        // Act
        var result = await _testService.CheckAndAssignTestAsync(testId, userId, chosenOptions);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(testId, result.TestId);
        Assert.Equal(100, result.Mark);
    }
}