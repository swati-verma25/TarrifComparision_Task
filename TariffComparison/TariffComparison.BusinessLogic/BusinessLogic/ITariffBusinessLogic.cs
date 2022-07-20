
using System.Collections.Generic;
using TarriffComparison.Entity.DTOs;

namespace TariffComparison.BusinessLogic.BusinessLogic
{
    /// <summary>
    /// ITariffBusinessLogic
    /// </summary>
    public interface ITariffBusinessLogic
    {
        /// <summary>
        /// Get products from repository
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns></returns>
        IEnumerable<TariffDTO> GetProducts(double consumption);
    }
}
