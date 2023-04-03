using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/mssource")]
    [ApiController]
    public class MsSourceController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsSourceRepositoryEF msSourceRepo;

        public MsSourceController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.msSourceRepo = new MsSourceRepositoryEF(_mastersContext);
        }

        [HttpGet("getsource")]
        public async Task<IActionResult> GetMsSource()
        {
            var msSource = await msSourceRepo.GetSourceAsync();
            return Ok(msSource);
        }
    }
}