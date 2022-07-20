
using System.Collections.Generic;
using TariffComparison.Repository.Entities;

namespace TariffComparison.Repository.Repositories
{
    /// <summary>
    /// ITariffRepository
    /// </summary>
    public interface ITariffRepository
    {
        /// <summary>
        /// GetAllProducts
        /// </summary>
        /// <returns></returns>
        IEnumerable<Tariff> GetAllProducts();
    }
}
