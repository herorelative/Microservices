using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microservices.DataAccess.Repository.IRepository;
using Microservices.Shared;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EVouchersController : ControllerBase
    {
        private readonly IEVoucherRepo _eVoucherRepo;
        private readonly IMapper _mapper;

        public EVouchersController(IEVoucherRepo eVoucherRepo, IMapper mapper)
        {
            _eVoucherRepo = eVoucherRepo;
            _mapper = mapper;
        }

        // GET: api/evouchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<eVoucherVM>>> GetAlleVouchers()
        {
            var eVouchers = await _eVoucherRepo.GetAlleVouchers();
            return Ok(_mapper.Map<IEnumerable<eVoucherVM>>(eVouchers));
        }

        // GET: api/evouchers/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<eVoucherVM>> GeteVoucherById(Guid Id)
        {
            var eVoucher = await _eVoucherRepo.GeteVoucherById(Id);
            if (eVoucher == null)
                return NotFound();

            return Ok(_mapper.Map<eVoucherVM>(eVoucher));
        }
    }
}