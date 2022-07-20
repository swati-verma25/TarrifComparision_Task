using System.Collections.Generic;
using System.Linq;
using TariffComparison.Repository.Entities;
using TariffComparison.Repository.Repositories;
using TarriffComparison.Entity.DTOs;

namespace TariffComparison.BusinessLogic.BusinessLogic
{
    /// <summary>
    /// TariffBusinessLogic
    /// </summary>
    public class TariffBusinessLogic : ITariffBusinessLogic
    {
        private ITariffRepository _tariffRepository;
        public TariffBusinessLogic(ITariffRepository tariffRepository)
        {
            _tariffRepository = tariffRepository;
        }

        /// <summary>
        /// Getting product data from repository
        /// </summary>
        /// <param name="consumption"></param>
        /// <returns></returns>
        public IEnumerable<TariffDTO> GetProducts(double consumption)
        {
            IEnumerable<Tariff> allTariffs = _tariffRepository.GetAllProducts();

            IEnumerable<TariffDTO> tariffDTOs = allTariffs.Select(tariff => new TariffDTO
            {
                Name = tariff.Name,
                AnnualCosts = tariff.CostsCalculation?.CalculateProductCosts(periodInMonths: 12, consumption) ?? 0,
            });

            IEnumerable<TariffDTO> sortedTariffDTOs = tariffDTOs.OrderBy(tariff => tariff.AnnualCosts);

            return sortedTariffDTOs;
        }
    }
}
