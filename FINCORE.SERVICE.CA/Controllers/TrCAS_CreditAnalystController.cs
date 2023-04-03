using FINCORE.LIBRARY.DTO.Model.Acquisition;
using FINCORE.SERVICE.CA.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CA.Controllers
{
    [Route("api/v0/services/acquisition/trcas_creditanalyst/")]
    [ApiController]
    public class TrCAS_CreditAnalystController : ControllerBase
    {
        private readonly ITrCAS_CreditAnalyst iTrCAS_CreditAnalyst;

        public TrCAS_CreditAnalystController(ITrCAS_CreditAnalyst _iTrCAS_CreditAnalyst)
        {
            this.iTrCAS_CreditAnalyst = _iTrCAS_CreditAnalyst;
        }

        [HttpPost("ef/save_trcas_creditanalyst")]
        public async Task<IActionResult> SaveCAS_CreditAnalystEF(TrCAS_CreditAnalyst trCAS_CreditAnalyst)
        {
            return Ok(await iTrCAS_CreditAnalyst.SaveCAS_CreditAnalyst(trCAS_CreditAnalyst));
        }
    }
}