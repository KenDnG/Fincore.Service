using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/roreferencesource")]
    [ApiController]
    public class MsROReferenceSourceController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsROReferenceSourceRepositoryEF rOReferenceSourceRepo;

        public MsROReferenceSourceController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.rOReferenceSourceRepo = new MsROReferenceSourceRepositoryEF(_mastersContext);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetROReferenceSource()
        {
            return Ok(await rOReferenceSourceRepo.GetReferenceSourceAsync());
        }
    }
}