using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.Shared.DTOs
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
    }
}
