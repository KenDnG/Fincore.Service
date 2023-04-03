using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/BPKBReason/")]
    [ApiController]
    public class MsBPKBReasonController : ControllerBase
    {
        private MastersContext mastersContext;
        private readonly MsBPKBReasonRepository repository;

        public MsBPKBReasonController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.repository = new MsBPKBReasonRepository(mastersContext);
        }
        
        [HttpGet("get")]
        public async Task<IActionResult> GetBPKBReason()
        {
            return Ok(await repository.GetMsBPKBReason());
        }
    }
}
