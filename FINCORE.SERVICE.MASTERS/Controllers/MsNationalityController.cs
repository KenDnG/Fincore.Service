using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/nationality/")]
    [ApiController]
    public class MsNationalityController : ControllerBase
    {
        private readonly IMsNationality msNationality;

        public MsNationalityController(IMsNationality msNationality)
        {
            this.msNationality = msNationality;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetNationality()
        {
            return Ok(await msNationality.GetNationalityAsync());
        }
    }
}