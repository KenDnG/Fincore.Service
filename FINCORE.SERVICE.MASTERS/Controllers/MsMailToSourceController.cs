using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/mailtosource/")]
    [ApiController]
    public class MsMailToSourceController : ControllerBase
    {
        private readonly IMsMailToSource msMailToSource;

        public MsMailToSourceController(IMsMailToSource msMailToSource)
        {
            this.msMailToSource = msMailToSource;
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetMailToSource()
        {
            return Ok(await msMailToSource.GetMailToSourceAsync());
        }
    }
}