using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.NPP.Repositories;
using FINCORE.SERVICE.NPP.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.NPP.Controllers
{
    [Route("api/v1/services/acquisition/npp/cm")]
    [ApiController]
    public class TrCMController : ControllerBase
    {
        private readonly TrCMRepository trCMRepository;

        public TrCMController(AcquisitionContext _acquisitionContext)
        {
            this.trCMRepository = new TrCMRepository(_acquisitionContext);
        }

        [HttpGet("byCreditId/{creditId}")]
        public async Task<IActionResult> GetCMByCreditId(string creditId)
        {
            return Ok(await trCMRepository.GetProcessCMByCreditId(creditId));
        }
    }
}