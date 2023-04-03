using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/residence")]
    [ApiController]
    public class MsResidenceStatusController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsResidenceRepositoryEF msResidenceStatusRepos;

        public MsResidenceStatusController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.msResidenceStatusRepos = new MsResidenceRepositoryEF(_mastersContext);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetResidenceStatus()
        {
            var residence = await msResidenceStatusRepos.GetResidenceAsync();
            return Ok(residence);
        }
    }
}