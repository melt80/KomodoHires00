using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using KomodoHires.Models.Contract;
using KomodoHires.Services.MockServices;
using KomodoHires.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class ContractTests
    {
        private ContractController _controller;
        private MockContractService _mockService;

        [TestInitialize]
        public void Arrange()
        {
            _mockService = new MockContractService { ReturnValue = true };
            _controller = new ContractController(_mockService);
        }

        [TestMethod]
        public void ContractController_PostContract_ShouldReturnOk()
        {
            var contract = new ContractCreate { ContractID = 1 };

            var result = _controller.Post(contract);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ContractController_DeleteContract_ShouldReturnCorrectInt()
        {
            _mockService.CallCount = 1;

            var result = _controller.Delete(1);

            Assert.AreEqual(0, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void ContractController_GetAll_CountShouldBeCorrectInt()
        {
            var result = _controller.GetAll();

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(
                result,
                typeof(OkNegotiatedContentResult<IEnumerable<ContractListItem>>)
            );
        }

        [TestMethod]
        public void ContractController_GetByID_CountShouldBeCorrectInt()
        {
            var result = _controller.Get(1);

            Assert.AreEqual(1, _mockService.CallCount);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<ContractDetail>));
        }
    }
}
