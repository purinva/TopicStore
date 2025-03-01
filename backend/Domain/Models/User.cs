﻿namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public List<Topic>? Topics { get; set; }
    }
}