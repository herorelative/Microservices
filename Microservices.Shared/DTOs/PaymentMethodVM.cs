using System;
using System.Collections.Generic;
using System.Text;

namespace Microservices.Shared.DTOs
{
    public class PaymentMethodVM
    {
        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}
