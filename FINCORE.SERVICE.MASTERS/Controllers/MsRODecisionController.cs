using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.CREDITS.Controllers
{
    [Route("api/v1/services/master/rodecision")]
    [ApiController]
    public class MsRODecisionController : ControllerBase
    {
        private readonly MastersContext masterContext;
        private readonly MsRODecisionRepositoryEF msRODecisionRepo;

        public MsRODecisionController(MastersContext _masterContext)
        {
            this.masterContext = _masterContext;
            this.msRODecisionRepo = new MsRODecisionRepositoryEF(_masterContext);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetRODecision()
        {
            return Ok(await msRODecisionRepo.GetRODecisionAsync());
        }
    }
}