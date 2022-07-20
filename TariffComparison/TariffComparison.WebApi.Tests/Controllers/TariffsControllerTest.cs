using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TariffComparison.BusinessLogic.BusinessLogic;
using TarriffComparison.Entity.DTOs;

namespace TariffComparison.WebApi.Controllers.Tests
{
    [TestClass]
    public class TariffsControllerTest
    {
        [TestMethod]
        public void GetTariffsByAnnualConsumption_ReturnsOk()
        {
            TariffsController controller = MockTarrifController();
            ActionResult<IEnumerable<TariffDTO>> actionResult = controller.GetTarriffByConsumption(annualConsumption: 700);
            Assert.IsNotNull(actionResult);
        }

        [TestMethod]
        public void GetTariffsByAnnualConsumption_ReturnsBadRequest()
        {
            TariffsController controller = MockTarrifController();
            ActionResult<IEnumerable<TariffDTO>> actionResult = controller.GetTarriffByConsumption(annualConsumption: -700);

            Assert.IsInstanceOfType(actionResult.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void GetTariffsByAnnualConsumption_Given4500KWh_ReturnsTariffDTOs()
        {
            TariffsController controller = MockTarrifController();
            ActionResult<IEnumerable<TariffDTO>> actionResult = controller.GetTarriffByConsumption(annualConsumption: 4500);
            Assert.IsInstanceOfType(actionResult.Result, typeof(ObjectResult));

            Assert.IsNotNull(actionResult);
        }

        private TariffsController MockTarrifController()
        {
            var mockTariffBL = new Mock<ITariffBusinessLogic>();
            mockTariffBL.Setup(repo => repo.GetProducts(300)).Returns(CreateTariffs);

            return new TariffsController(mockTariffBL.Object);
        }

        private IEnumerable<TariffDTO> CreateTariffs()
        {
            List<TariffDTO> list = new List<TariffDTO>();
            list.Add(new TariffDTO { AnnualCosts = 500, Name = "Test 1" });
            list.Add(new TariffDTO { AnnualCosts = 1500, Name = "Test 2" });
            return list;
        }
    }
}
