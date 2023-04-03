using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/evaluation")]
    [ApiController]
    public class MsEvaluationController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsEvaluationRepositoryEF msEvaluationRepository;

        public MsEvaluationController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.msEvaluationRepository = new MsEvaluationRepositoryEF(mastersContext);
        }

        [HttpGet("getcreditevaluations")]
        public async Task<IActionResult> GetCreditEvaluations()
        {
            var creditEvaluations = await msEvaluationRepository.GetCreditEvaluationsAsync();
            return Ok(creditEvaluations);
        }
    }
}