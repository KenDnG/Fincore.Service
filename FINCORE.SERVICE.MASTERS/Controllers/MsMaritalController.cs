using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/marital")]
    [ApiController]
    public class MsMaritalController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsMaritalRepositoryEF msMaritalRepository;

        public MsMaritalController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.msMaritalRepository = new MsMaritalRepositoryEF(mastersContext);
        }

        [HttpGet("getmarital")]
        public async Task<IActionResult> GetMsMaritalStatus()
        {
            var marital = await msMaritalRepository.GetMaritalStatusAsync();
            return Ok(marital);
        }
    }
}