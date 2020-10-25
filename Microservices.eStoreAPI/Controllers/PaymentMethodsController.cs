using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microservices.DataAccess.Repository.IRepository;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Microservices.eStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodsController : ControllerBase
    {
        private readonly IPaymentMethodRepo _paymentMethodRepo;
        private readonly IMapper _mapper;

        public PaymentMethodsController(IPaymentMethodRepo paymentMethodRepo, IMapper mapper)
        {
            _paymentMethodRepo = paymentMethodRepo;
            _mapper = mapper;
        }

        // GET: api/paymentmethods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethodVM>>> Get()
        {
            var paymentmethods = await _paymentMethodRepo.GetAllPaymentMethods();
            return Ok(_mapper.Map<IEnumerable<PaymentMethodVM>>(paymentmethods));
        }
    }
}
