using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TariffComparison.BusinessLogic.BusinessLogic;
using TarriffComparison.Entity.DTOs;

namespace TariffComparison.WebApi.Controllers
{
    /// <summary>
    /// TarrifController 
    /// </summary>
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TariffsController : ControllerBase
    {
        /// <summary>
        /// ITariffBusinessLogic
        /// </summary>
        private ITariffBusinessLogic _tariffBusinessLogic;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="tariffBusinessLogic"></param>
        public TariffsController(ITariffBusinessLogic tariffBusinessLogic)
        {
            _tariffBusinessLogic = tariffBusinessLogic;
        }

        /// <summary>
        /// Get Tarriff consumption based on the annual consumption
        /// </summary>
        /// <param name="annualConsumption"></param>
        /// <returns></returns>
        [HttpGet("GetTarriffByConsumption/{annualConsumption}")]
        public ActionResult<IEnumerable<TariffDTO>> GetTarriffByConsumption(double annualConsumption)
        {
            if (annualConsumption > 0)
            {
                var result = _tariffBusinessLogic.GetProducts(annualConsumption);
                return Ok(result?.ToArray());
            }
            else
            {
                return BadRequest(new ErrorDTO(400, "Annual comsumption must not be negative"));
            }
        }
    }
}
