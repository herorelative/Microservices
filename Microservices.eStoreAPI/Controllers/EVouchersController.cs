using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microservices.DataAccess.Repository.IRepository;
using Microservices.Shared;
using Microservices.Shared.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Microservices.eStoreAPI.Controllers
{
    [Authorize]
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
        //[Authorize]
        public async Task<ActionResult<eVoucherVM>> GeteVoucherById(Guid Id)
        {
            var eVoucher = await _eVoucherRepo.GeteVoucherById(Id);
            if (eVoucher == null)
                return NotFound();

            return Ok(_mapper.Map<eVoucherVM>(eVoucher));
        }

        //POST: api/evouchers/
        [HttpPost]
        public async Task<ActionResult<eVoucherVM>> CreateEvoucher(eVoucherCreateVM model)
        {
            var eVoucherModel = _mapper.Map<EVoucher>(model);
            await _eVoucherRepo.CreateEVoucher(eVoucherModel);
            await _eVoucherRepo.SaveChanges();

            var evoucherVM = _mapper.Map<eVoucherVM>(eVoucherModel);

            return Created("evoucher", evoucherVM);
        }

        //PUT: api/evouchers/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEvoucher(Guid id,eVoucherUpdateVM model)
        {
            var evoucherModelFromRepo = await _eVoucherRepo.GeteVoucherById(id);
            
            if (evoucherModelFromRepo == null)
                return NotFound();

            _mapper.Map(model, evoucherModelFromRepo);

            //the following will not do anything, but it is here to support other ORM
            //and reduce maintenance work
            _eVoucherRepo.UpdateEVoucher(evoucherModelFromRepo);
            await _eVoucherRepo.SaveChanges();
            return NoContent();
        }

        //PATCH: api/evouchers/{id}
        [HttpPatch("{id}")]
        public async Task<ActionResult> PartialeVoucherUpdate(Guid id,JsonPatchDocument<eVoucherUpdateVM> patcheVoucher)
        {
            var evoucherModelFromRepo = await _eVoucherRepo.GeteVoucherById(id);
            if (evoucherModelFromRepo == null)
                return NotFound();

            var evoucherToPatch = _mapper.Map<eVoucherUpdateVM>(evoucherModelFromRepo);
            patcheVoucher.ApplyTo(evoucherToPatch, ModelState);

            if (!TryValidateModel(evoucherToPatch))
                return ValidationProblem(ModelState);

            _mapper.Map(evoucherToPatch, evoucherModelFromRepo);

            //the following will not do anything, but it is here to support other ORM
            //and reduce maintenance work
            _eVoucherRepo.UpdateEVoucher(evoucherModelFromRepo);

            await _eVoucherRepo.SaveChanges();

            return NoContent();
        }

        //DELETE: api/evouchers/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEVoucher(Guid id)
        {
            var evoucherModelFromRepo = await _eVoucherRepo.GeteVoucherById(id);

            if (evoucherModelFromRepo == null)
                return NotFound();

            _eVoucherRepo.DeleteEVoucher(evoucherModelFromRepo);
            await _eVoucherRepo.SaveChanges();

            return NoContent();
        }
    }
}