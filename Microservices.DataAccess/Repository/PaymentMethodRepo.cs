using Microservices.DataAccess.Repository.IRepository;
using Microservices.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.DataAccess.Repository
{
    public class PaymentMethodRepo : IPaymentMethodRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PaymentMethodRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods()
        {
            return await _applicationDbContext.PaymentMethods.ToListAsync();
        }
    }
}
