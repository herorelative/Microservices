using Microservices.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.DataAccess.Repository.IRepository
{
    public interface IPaymentMethodRepo
    {
        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods();
    }
}
