using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/approval-reason/")]
    [ApiController]
    public class MsApprovalReasonController : ControllerBase
    {
        private MastersContext mastersContext;
        private readonly MsApprovalReasonRepository repository;

        public MsApprovalReasonController(MastersContext mastersContext)
        {
            this.mastersContext = mastersContext;
            this.repository = new MsApprovalReasonRepository(mastersContext);
        }

        [HttpGet("byId/{ReasonId}")]
        public async Task<IActionResult> GetAllApprovalReasonByReasonId(string ReasonId)
        {
            return Ok(await repository.GetByIdAsync(ReasonId));
        }


        [HttpGet("byType/{Type}")]
        public async Task<IActionResult> GetAllApprovalReasonByType(string Type)
        {
            return Ok(await repository.GetByTypeAsync(Type));
        }
    }
}
