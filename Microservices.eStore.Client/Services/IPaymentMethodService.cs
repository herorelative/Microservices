using Microservices.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Services
{
    public interface IPaymentMethodService
    {
        Task<IEnumerable<PaymentMethodVM>> GetAllPaymentMethods();
    }
}
