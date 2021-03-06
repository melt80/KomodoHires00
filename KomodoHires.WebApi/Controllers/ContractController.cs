﻿using KomodoHires.Contracts;
using KomodoHires.Models.Contract;
using KomodoHires.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KomodoHires.WebApi.Controllers
{
    public class ContractController : ApiController
    {
        private IContractService _contractService;

        public ContractController() { }
        public ContractController(IContractService mockService)
        {
            _contractService = mockService;
        }
        public IHttpActionResult GetAll()
        {
            PopulateContractService();
            var contracts = _contractService.GetContracts();
            return Ok(contracts);
        }

        public IHttpActionResult Get(int id)
        {
            PopulateContractService();
            var contract = _contractService.GetContractById(id);
            return Ok(contract);
        }

        private ContractService CreateContractService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var contractService = new ContractService(userId);
            return contractService;
        }

        public IHttpActionResult Post(ContractCreate contract)
        {
            PopulateContractService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_contractService.CreateContract(contract))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(ContractEdit contract)
        {
            PopulateContractService();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_contractService.UpdateContract(contract))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            PopulateContractService();
            if (!_contractService.DeleteContract(id))
                return InternalServerError();

            return Ok();
        }

        private void PopulateContractService()
        {
            if (_contractService == null)
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                _contractService = new ContractService(userId);
            }
        }
    }
}
