using System;
using System.ComponentModel.DataAnnotations;

namespace Microservices.Shared.DTOs
{
    public class eVoucherPatchVM
    {
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
        public Guid PaymentMethodId { get; set; }

        [Required]
        public int DiscountOnPaymentMethod { get; set; }

        [Required]
        public int Quantity { get; set; }

        public BuyType BuyType { get; set; }

        public bool IsActive { get; set; }
    }
}
