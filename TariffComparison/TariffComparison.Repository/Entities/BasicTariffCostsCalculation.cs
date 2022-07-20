using System;
using TariffComparison.Repository.Interface;

namespace TariffComparison.Repository.Entities
{
    /// <summary>
    /// BasicTariffCostsCalculation
    /// </summary>
    public class BasicTariffCostsCalculation : ITariffCostsCalculation
    {
        public double BaseCostsPerMonth { get; set; }

        public double ConsumptionCostsPerKWh { get; set; }

        public double CalculateProductCosts(int periodInMonths, double consumptionInKWh)
        {
            if (periodInMonths < 0)
                throw new ArgumentException("Period must not be negative");

            if (consumptionInKWh < 0)
                throw new ArgumentException("Consumption must not be negative");

            return BaseCostsPerMonth * periodInMonths + ConsumptionCostsPerKWh * consumptionInKWh;
        }
    }
}
