﻿namespace Application.Security
{
    public interface IJwtProvider
    {
        string GenerateToken(Guid id, string username);
    }
}