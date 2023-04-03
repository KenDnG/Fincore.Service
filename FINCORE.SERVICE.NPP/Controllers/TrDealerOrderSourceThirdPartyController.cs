using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.NPP.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.NPP.Controllers
{
    [Route("api/v1/services/acquisition/npp/dealer-order-source-tp/")]
    [ApiController]
    public class TrDealerOrderSourceThirdPartyController : ControllerBase
    {
        private readonly TrDealerOrderSourceThirdPartyRepository dealerOrderSourceTPRepo;

        public TrDealerOrderSourceThirdPartyController(AcquisitionContext acqusitionContext)
        {
            this.dealerOrderSourceTPRepo = new TrDealerOrderSourceThirdPartyRepository(acqusitionContext);
        }

        [HttpGet("realDatabyCreditId/{creditId}")]
        public async Task<IActionResult> GetRealDataByCreditId(string creditId)
        {
            return Ok(await dealerOrderSourceTPRepo.GetRealDataByCreditId(creditId));
        }

        [HttpGet("manipulateDatabyCreditId/{creditId}")]
        public async Task<IActionResult> GetManipulateDataByCreditId(string creditId)
        {
            return Ok(await dealerOrderSourceTPRepo.GetManipulateDataByCreditId(creditId));
        }
    }
}