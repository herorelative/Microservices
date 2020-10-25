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
    public class EVoucherRepo : IEVoucherRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EVoucherRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void ChangeActiveStatus(Guid Id)
        {
            //no need to implement in using entityframework core
            //but have created to use for other provider
            throw new NotImplementedException();
        }

        public async Task CreateEVoucher(EVoucher evoucher)
        {
            if (evoucher == null)
                throw new ArgumentNullException(nameof(evoucher));

            await _applicationDbContext.EVouchers.AddAsync(evoucher);
        }

        public void DeleteEVoucher(EVoucher evoucher)
        {
            if (evoucher == null)
                throw new ArgumentNullException(nameof(evoucher));

            _applicationDbContext.EVouchers.Remove(evoucher);
        }

        public async Task<IEnumerable<EVoucher>> GetAlleVouchers()
        {
            return await _applicationDbContext.EVouchers.ToListAsync(); 
        }

        public async Task<EVoucher> GeteVoucherById(Guid Id)
        {
            return await _applicationDbContext.EVouchers.FirstOrDefaultAsync(e=>e.Id == Id);
        }

        public async Task<bool> SaveChanges()
        {
            return await _applicationDbContext.SaveChangesAsync() > 0;
        }

        public void UpdateEVoucher(EVoucher evoucher)
        {
            //no need to implement in using entityframework core
            //but have created to use for other provider
            throw new NotImplementedException();
        }
    }
}