using Microservices.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Services
{
    public interface IAuthService
    {
        Task<LoginResult> Login(LoginVM loginModel);
        Task Logout();
        Task<RegisterResult> Register(UserRegisterVM registerModel);
        Task<string> RefreshToken();
    }
}