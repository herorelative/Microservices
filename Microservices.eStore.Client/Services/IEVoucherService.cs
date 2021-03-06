﻿using Microservices.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microservices.eStore.Client.Services
{
    public interface IEVoucherService
    {
        Task<IEnumerable<eVoucherVM>> GetAllEvouchers();
        Task<eVoucherVM> GetAnEvoucher(Guid Id);
        Task<eVoucherVM> AddEvoucher(eVoucherCreateVM evoucher);
        Task UpdateAnEvoucher(Guid Id, eVoucherUpdateVM evoucher);
        Task ChangeActiveStatusEvoucher(Guid Id);
        Task DeleteAnEvoucher(Guid Id);
        Task<string> UploadEvoucherImage(MultipartFormDataContent content);
    }
}
