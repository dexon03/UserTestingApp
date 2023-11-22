﻿namespace UserTestingAPI.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }
    
    public ICollection<UserTests> CompletedTests { get; set; }
}