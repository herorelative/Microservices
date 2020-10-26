using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.Shared.DTOs
{
    public class eVoucherVM
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime ExpireDate { get; set; }

        public string Image { get; set; }

        public double Amount { get; set; }

        public Guid PaymentMethodId { get; set; }
        public PaymentMethodVM DicountedPaymentMethod { get; set; }

        public int DiscountOnPaymentMethod { get; set; }

        public int Quantity { get; set; }

        public BuyType BuyType { get; set; }

        public bool IsActive { get; set; }
    }
}
