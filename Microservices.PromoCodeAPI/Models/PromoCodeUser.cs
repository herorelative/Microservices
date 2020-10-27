using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.PromoCodeAPI.Models
{
    public class PromoCodeUser : IdentityUser
    {
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string Name { get; set; }
        public int MaxBuyLimit { get; set; } = 1000;
        public int MaxBuyGiftLimit { get; set; } = 10;
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}