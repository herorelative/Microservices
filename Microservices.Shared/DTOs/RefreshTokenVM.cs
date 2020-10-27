using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.Shared.DTOs
{
    public class RefreshTokenVM
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
