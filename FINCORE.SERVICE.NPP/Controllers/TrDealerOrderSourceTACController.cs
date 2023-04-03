using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.NPP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.NPP.Controllers
{
    [Route("api/v1/services/acquisition/npp/dealer-order-source-tac/")]
    [ApiController]
    public class TrDealerOrderSourceTACController : ControllerBase
    {
        private readonly TrDealerOrderSourceTACRepository dealerOrderSourceTACRepo;

        public TrDealerOrderSourceTACController(AcquisitionContext acquisitionContext)
        {
            this.dealerOrderSourceTACRepo = new TrDealerOrderSourceTACRepository(acquisitionContext);
        }

        [HttpGet("realDatabyCreditId/{creditId}")]
        public async Task<IActionResult> GetRealDataByCreditId(string creditId)
        {
            return Ok(await dealerOrderSourceTACRepo.GetRealDataByCreditId(creditId));
        }

        [HttpGet("manipulateDatabyCreditId/{creditId}")]
        public async Task<IActionResult> GetManipulateDataByCreditId(string creditId)
        {
            return Ok(await dealerOrderSourceTACRepo.GetManipulateDataByCreditId(creditId));
        }
    }
}