using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/BPKBLocation/")]
    [ApiController]
    public class MsBPKBLocationController : ControllerBase
    {
        private MastersContext mastersContext;
        private readonly MsBPKBLocationRepository repository ;

        public MsBPKBLocationController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.repository = new MsBPKBLocationRepository(mastersContext);
        }

        [HttpPost("get")]
        public async Task<IActionResult> GetBPKBLocation(string branchid)
        {
            return Ok(await repository.GetBPKBLocation(branchid));
        }

    }
}
