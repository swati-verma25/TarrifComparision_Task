using System.Collections.Generic;
using TariffComparison.Repository.Entities;

namespace TariffComparison.Repository.Repositories
{
    /// <summary>
    /// TariffRepository
    /// </summary>
    public class TariffRepository : ITariffRepository
    {
        /// <summary>
        /// GetAllProducts --getting product data --currently doing hard code 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Tariff> GetAllProducts()
        {
            IList<Tariff> product = new List<Tariff>
            {
                new Tariff
                {
                    Name = "basic electricity tariff",
                    CostsCalculation = new BasicTariffCostsCalculation
                    {
                        BaseCostsPerMonth = 5,
                        ConsumptionCostsPerKWh = 0.22,
                    }
                },

                new Tariff
                {
                    Name = "Packaged tariff",
                    CostsCalculation = new PackagedTariffCostsCalculation
                    {
                        AnnualBaseCosts = 800,
                        AnnualBaseCostsLimitInKWh = 4000,
                        ConsumptionCostsPerKWh = 0.30,
                    }
                }
            };

            return product;
        }
    }
}
