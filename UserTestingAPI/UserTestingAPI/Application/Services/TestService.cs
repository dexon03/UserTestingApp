using System.Net;
using Microsoft.EntityFrameworkCore;
using UserTestingAPI.Core.Exceptions;
using UserTestingAPI.Core.Repository;
using UserTestingAPI.Domain.Contracts;
using UserTestingAPI.Domain.Dtos;
using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Application.Services;

public class TestService : ITestService
{
    private readonly IRepository _repository;

    public TestService(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UserTestDto>> GetAssignedTestsForUserAsync(Guid userId)
    {
        var isUserExists = await _repository.GetByIdAsync<User>(userId);
        if (isUserExists == null)
        {
            throw new ExceptionWithStatusCode("User not found", HttpStatusCode.NotFound);
        }
        var completedTests = await 
            (from assignedTest in _repository.GetAll<UserTests>().Where(ct => ct.UserId == userId)
                join test in _repository.GetAll<Test>() on assignedTest.TestId equals test.Id
                select new UserTestDto
                {
                    TestId = assignedTest.TestId,
                    TestTitle = test.Title,
                    Mark = assignedTest.Mark,
                    CompletionDate = assignedTest.CompletionDate
                }).ToListAsync();

        return completedTests;
    }

    public async Task<TestDto> GetTestByIdAsync(Guid userId, Guid testId)
    {
        var isUserExists = await _repository.AnyAsync<User>(u => u.Id == userId);
        if (!isUserExists)
        {
            throw new ExceptionWithStatusCode("User not found", HttpStatusCode.NotFound);
        }
        var isTestForUserCompletedOrNotAssigned = await _repository.AnyAsync<UserTests>(ut => ut.UserId == userId && ut.TestId == testId && ut.Mark != null);
        if (isTestForUserCompletedOrNotAssigned)
        {
            throw new ExceptionWithStatusCode("Test is already completed or not assigned", HttpStatusCode.BadRequest);
        }

        var testDto = GetTest(testId);
        if (testDto?.Questions is null)
        {
            throw new ExceptionWithStatusCode("Test not found or not valid", HttpStatusCode.BadRequest);
        }
        return testDto;
    }

    private TestDto? GetTest(Guid testId)
    {
        var result =
            (from test in _repository.GetAll<Test>().Where(t => t.Id == testId)
                join questions in _repository.GetAll<Question>() 
                    on test.Id equals questions.TestId into temp
                from question in temp.DefaultIfEmpty()
                join options in _repository.GetAll<Option>() 
                    on question.Id equals options.QuestionId into temp2
                from option in temp2.DefaultIfEmpty()
                select new
                {
                    TestId = test.Id,
                    TestTitle = test.Title,
                    QuestionId = question == null ? Guid.Empty : question.Id ,
                    QuestionText = question == null ? string.Empty : question.Text,
                    OptionId = option == null ? Guid.Empty : option.Id,
                    OptionText = option == null ? string.Empty : option.Text
                })
            .ToList()
            .GroupBy(t => new
            {
                t.TestId,
                t.TestTitle
            })
            .Select(gt => new TestDto
            {
                Id = gt.Key.TestId,
                Title = gt.Key.TestTitle,
                Questions = gt.All(_ => _.QuestionId == Guid.Empty) ? null : gt.GroupBy(q => new
                {
                    q.QuestionId,
                    q.QuestionText
                }).Select(gq => new QuestionWithOptions
                {
                    Id = gq.Key.QuestionId,
                    Text = gq.Key.QuestionText,
                    Options = gq.Select(o => new OptionDto
                    {
                        Id = o.OptionId,
                        Text = o.OptionText
                    }).ToList()
                })
            }).FirstOrDefault();
        return result;
    }
}