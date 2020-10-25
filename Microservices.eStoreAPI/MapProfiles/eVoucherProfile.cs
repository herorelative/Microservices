using AutoMapper;
using Microservices.Shared;
using Microservices.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.eStoreAPI.MapProfiles
{
    public class eVoucherProfile : Profile
    {
        public eVoucherProfile()
        {
            CreateMap<EVoucher, eVoucherVM>();
        }
    }
}
