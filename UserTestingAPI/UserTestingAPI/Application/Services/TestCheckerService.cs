using System.Net;
using UserTestingAPI.Core.Exceptions;
using UserTestingAPI.Core.Repository;
using UserTestingAPI.Domain.Contracts;
using UserTestingAPI.Domain.Dtos;
using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Application.Services;

public class TestCheckerService : ITestCheckerService
{
    private readonly IRepository _repository;

    public TestCheckerService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<UserTestDto> CheckAndAssignTestAsync(Guid testId, Guid userId, List<Guid> chosenOptions)
    {
        var testWithQuestions = GetTestWithQuestions(testId); 
        if (testWithQuestions is null)
        {
            throw new ExceptionWithStatusCode("Test not found", HttpStatusCode.BadRequest);
        }

        var totalPoint = CalculatePoints(testWithQuestions, chosenOptions);
        
        var userTest = new UserTests
        {
            Id = Guid.NewGuid(),
            UserId = userId,
            TestId = testId,
            Mark = totalPoint,
            CompletionDate = DateTime.UtcNow
        };
        await _repository.CreateAsync(userTest);
        await _repository.SaveChangesAsync();
        return userTest.ToDto(testWithQuestions.TestTitle);
    }
    
    private TestWithQuestions? GetTestWithQuestions(Guid testId)
    {
        return (from test in _repository.GetAll<Test>().Where(t => t.Id == testId) 
                join question in _repository.GetAll<Question>() on test.Id equals question.TestId 
                select new 
                {
                    TestId = test.Id,
                    test.Title,
                    QuestionId = question.Id,
                    question.CorrectOptionId,
                })
            .ToList()
            .GroupBy(t => new
            {
                t.TestId,
                t.Title
            })
            .Select(gt => new TestWithQuestions
            {
                TestId = gt.Key.TestId,
                TestTitle = gt.Key.Title,
                Questions = gt.Select(q => new QuestionWithCorrectOption
                {
                    QuestionId = q.QuestionId,
                    CorrectOptionId = q.CorrectOptionId,
                })
            })
            .FirstOrDefault();
    }
    
    private int CalculatePoints(TestWithQuestions testWithQuestions, List<Guid> chosenOptions)
    {
        var pointsPerQuestion = 100 / testWithQuestions.Questions.Count();
        var totalPoint = 0;

        foreach (var question in testWithQuestions.Questions)
        {
            var isCorrect = chosenOptions.Contains(question.CorrectOptionId);
            if (isCorrect)
            {
                totalPoint += pointsPerQuestion;
            }
        }

        return totalPoint;
    }
}

