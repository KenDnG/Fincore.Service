using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/disbursal-type-umc/")]
    [ApiController]
    public class MsDisbursalTypeUMCController : ControllerBase
    {
        private MastersContext mastersContext;
        private readonly MsDisbursalTypeUMCRepository repository;

        public MsDisbursalTypeUMCController(MastersContext mastersContext)
        {
            this.mastersContext = mastersContext;
            this.repository = new MsDisbursalTypeUMCRepository(mastersContext);
        }

        [HttpGet("byBranchId/{BranchId}")]
        public async Task<IActionResult> GetAllDealerBankReferenceByDealerCode(string BranchId)
        {
            return Ok(await repository.GetByIdAsync(BranchId));
        }
    }
}