using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/ownershipproof")]
    [ApiController]
    public class MsOwnershipProofController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsOwnershipProofRepositoryEF msOwnershipProofRepository;

        public MsOwnershipProofController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.msOwnershipProofRepository = new MsOwnershipProofRepositoryEF(_mastersContext);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetMsOwnershipProof()
        {
            var proof = await msOwnershipProofRepository.GetOwnershipProofAsync();
            return Ok(proof);
        }
    }
}