using Microservices.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.DataAccess.Repository.IRepository
{
    public interface IEVoucherRepo
    {
        Task<IEnumerable<EVoucher>> GetAlleVouchers();
        Task<EVoucher> GeteVoucherById(Guid Id);
        Task CreateEVoucher(EVoucher evoucher);
        void UpdateEVoucher(EVoucher evoucher);
        void ChangeActiveStatus(Guid Id);
        void DeleteEVoucher(EVoucher evoucher);
        Task<bool> SaveChanges();
    }
}
