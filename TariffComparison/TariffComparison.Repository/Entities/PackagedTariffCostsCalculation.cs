using System;
using TariffComparison.Repository.Interface;

namespace TariffComparison.Repository.Entities
{
    /// <summary>
    /// PackagedTariffCostsCalculation
    /// </summary>
    public class PackagedTariffCostsCalculation : ITariffCostsCalculation
    {
        public double AnnualBaseCostsLimitInKWh { get; set; }

        public double AnnualBaseCosts { get; set; }

        public double ConsumptionCostsPerKWh { get; set; }

        public double CalculateProductCosts(int periodInMonths, double consumptionInKWh)
        {
            if (periodInMonths < 0)
                throw new ArgumentException("Period must not be negative");

            if (consumptionInKWh < 0)
                throw new ArgumentException("Consumption must not be negative");

            double baseCosts = AnnualBaseCosts / 12 * periodInMonths;

            if (consumptionInKWh / periodInMonths <= AnnualBaseCostsLimitInKWh / 12)
                return baseCosts;

            double baseCostsLimit = AnnualBaseCostsLimitInKWh / 12 * periodInMonths;
            return baseCosts + ((consumptionInKWh - baseCostsLimit) * ConsumptionCostsPerKWh);
        }
    }
}
