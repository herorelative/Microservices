using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreJWTExample.Helpers
{
    public class AppSettings
    {
        public string JwtSecurityKey { get; set; }
        public string JwtIssuer { get; set; }
        public string JwtAudience { get; set; }
        public int JwtExpiryInDays { get; set; }
    }
}
