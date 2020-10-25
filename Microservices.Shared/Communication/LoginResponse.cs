using Microservices.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.Shared.Communication
{
    public class LoginResponse : BaseResponse
    {
        public LoginResult Result { get; set; }
        private LoginResponse(bool success, string message, LoginResult token) : base(success, message)
        {
            Result = token;
        }
        public LoginResponse(LoginResult token) : this(true, string.Empty, token) { }
        public LoginResponse(string message) : this(false, message, null) { }
    }
}
