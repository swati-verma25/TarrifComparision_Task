
using TariffComparison.Repository.Interface;

namespace TariffComparison.Repository.Entities
{
    /// <summary>
    /// Tariff
    /// </summary>
    public class Tariff
    {
        public string Name { get; set; }

        public ITariffCostsCalculation CostsCalculation { get; set; }
    }
}
