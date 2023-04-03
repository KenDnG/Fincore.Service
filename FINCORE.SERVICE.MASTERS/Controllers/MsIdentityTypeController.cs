using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/identity")]
    [ApiController]
    public class MsIdentityTypeController : ControllerBase
    {
        private readonly IMsIdentityType iIdentityType;

        public MsIdentityTypeController(IMsIdentityType identityType)
        {
            this.iIdentityType = identityType;
        }

        [HttpGet("getidentitytype")]
        public async Task<IActionResult> GetMsIdentityType()
        {
            var identity = await iIdentityType.GetIdentityTypeAsync();
            return Ok(identity);
        }

        [HttpGet("getidentitytypebycustomertype")]
        public async Task<IActionResult> GetMsIdentityType(string customerType)
        {
            var identity = await iIdentityType.GetIdentityTypeAsync(customerType);
            return Ok(identity);
        }
    }
}