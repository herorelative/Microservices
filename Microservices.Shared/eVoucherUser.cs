using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Microservices.Shared
{
    public class eVoucherUser : IdentityUser
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int MaxBuyLimit { get; set; } = 1000;
        public int MaxBuyGiftLimit { get; set; } = 10;
    }
}
