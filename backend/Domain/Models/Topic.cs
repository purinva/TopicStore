﻿namespace Domain.Entities
{
    public class Topic
    {
        public Guid TopicId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime EventStart { get; set; }
        public Guid UserId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}