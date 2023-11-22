using UserTestingAPI.Application.Utilities;
using UserTestingAPI.Domain.Entities;

namespace UserTestingAPI.Database.Seed;

public static class DbSeed
{
    public static User GetSeedUser()
    {
        var passwordSalt = PasswordUtility.CreatePasswordSalt();
        var passwordHash = PasswordUtility.GetHashedPassword("default", passwordSalt);
        return new User
        {
            Id = Guid.NewGuid(),
            Email = "default@mail.com",
            PasswordSalt = passwordSalt,
            PasswordHash = passwordHash
        };
    }

    public static List<Test> GetSeedTest()
    {
        return new List<Test>
        {
            new Test
            {
                Id = Guid.NewGuid(),
                Title = "Test 1",
            },
            new Test
            {
                Id = Guid.NewGuid(),
                Title = "Test 2",
            },
        };
    }

    public static List<UserTests> GetSeedAsssignedAndCompletedTest(User user, List<Test> tests)
    {
        var userTests = new List<UserTests>
        {
            new UserTests
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                TestId = tests[0].Id,
                Mark = 100,
                CompletionDate = DateTime.UtcNow
            },
            new UserTests
            {
                Id = Guid.NewGuid(),
                UserId = user.Id,
                TestId = tests[1].Id,
                Mark = null,
                CompletionDate = null
            },
        };
        return userTests;
    }

    public static List<Question> GetSeedQuestions(List<Test> test)
    {
        return new List<Question>
        {
            new Question
            {
                Id = Guid.NewGuid(),
                TestId = test[0].Id,
                Text = "Question 1",
            },
            new Question
            {
                Id = Guid.NewGuid(),
                TestId = test[0].Id,
                Text = "Question 2",
            },
            new Question
            {
                Id = Guid.NewGuid(),
                TestId = test[1].Id,
                Text = "Question 1",
            },
            new Question
            {
                Id = Guid.NewGuid(),
                TestId = test[1].Id,
                Text = "Question 2",
            }
        };
    }
    
    public static List<Option> GetSeedOptions(List<Question> question)
    {
        var optionsTest1 = new List<Option>
        {
            new Option
            {
                Id = Guid.NewGuid(),
                QuestionId = question[0].Id,
                Text = "Option 1",
            },
            new Option
            {
                Id = Guid.NewGuid(),
                QuestionId = question[0].Id,
                Text = "Option 2",
            },
            new Option
            {
                Id = Guid.NewGuid(),
                QuestionId = question[1].Id,
                Text = "Option 1",
            },
            new Option
            {
                Id = Guid.NewGuid(),
                QuestionId = question[1].Id,
                Text = "Option 2",
            },
        };
        var optionsTest2 = new List<Option>
        {
            new Option
            {
                Id = Guid.NewGuid(),
                QuestionId = question[2].Id,
                Text = "Option 1",
            },
            new Option
            {
                Id = Guid.NewGuid(),
                QuestionId = question[2].Id,
                Text = "Option 2",
            },
            new Option
            {
                Id = Guid.NewGuid(),
                QuestionId = question[3].Id,
                Text = "Option 1",
            },
            new Option
            {
                Id = Guid.NewGuid(),
                QuestionId = question[3].Id,
                Text = "Option 2",
            },
        };
        
        question[0].CorrectOptionId = optionsTest1[0].Id;
        question[1].CorrectOptionId = optionsTest1[2].Id;
        question[2].CorrectOptionId = optionsTest2[0].Id;
        question[3].CorrectOptionId = optionsTest2[2].Id;
        optionsTest1.AddRange(optionsTest2);
        return optionsTest1;
    }
}