using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.BusinessLogic.BusinessLogic;
using TariffComparison.Repository.Entities;
using TariffComparison.Repository.Repositories;

namespace TarrifComparison.Businesslogic.Test.Businesslogic
{
    [TestClass]
    public class TariffBusinessLogicTest
    {
        [TestMethod]
        public void Test_GetProducts()
        {
            TariffBusinessLogic bl = MockTarrifBL();
            var actionResult = bl.GetProducts(700);
            Assert.IsNotNull(actionResult);
            var arrayObj = actionResult.ToArray();
            Assert.AreEqual(2, arrayObj.Count());
        }


        private TariffBusinessLogic MockTarrifBL()
        {
            var mockTariffBL = new Mock<ITariffRepository>();
            mockTariffBL.Setup(repo => repo.GetAllProducts()).Returns(CreateTariffs);

            return new TariffBusinessLogic(mockTariffBL.Object);
        }


        private IEnumerable<Tariff> CreateTariffs()
        {
            yield return new Tariff
            {
                Name = "A",
                CostsCalculation = new BasicTariffCostsCalculation
                {
                    BaseCostsPerMonth = 5,
                    ConsumptionCostsPerKWh = 0.22,
                }
            };

            yield return new Tariff
            {
                Name = "B",
                CostsCalculation = new PackagedTariffCostsCalculation
                {
                    AnnualBaseCosts = 800,
                    AnnualBaseCostsLimitInKWh = 4000,
                    ConsumptionCostsPerKWh = 0.30,
                }
            };

        }
    }
}
