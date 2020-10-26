using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Microservices.Shared
{
    [Table("evoucher")]
    public class EVoucher
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(256)]
        public string Description { get; set; }
        
        [Required]
        public DateTime ExpireDate { get; set; }
        
        public string Image { get; set; }
        
        [Required]
        public double Amount { get; set; }

        [Required]
        [ForeignKey(nameof(PaymentMethod))]
        public Guid PaymentMethodId { get; set; }
        public virtual PaymentMethod DicountedPaymentMethod { get; set; }

        [Required]
        public int DiscountOnPaymentMethod { get; set; }
        
        [Required]
        public int Quantity { get; set; }

        public BuyType BuyType { get; set; } = BuyType.OnlyMeUsage;

        public bool IsActive { get; set; } = true;
    }
}