

namespace TariffComparison.Repository.Interface
{
    /// <summary>
    /// ITariffCostsCalculation
    /// </summary>
    public interface ITariffCostsCalculation
    {
        /// <summary>
        /// calculation product cose
        /// </summary>
        /// <param name="periodInMonths"></param>
        /// <param name="consumptionInKWh"></param>
        /// <returns></returns>
        double CalculateProductCosts(int periodInMonths, double consumptionInKWh);
    }
}
