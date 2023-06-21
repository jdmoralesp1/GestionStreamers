﻿using CleanArquitecture.Application.Models.Identity;

namespace CleanArquitecture.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
