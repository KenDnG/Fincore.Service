using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/applicantrelation")]
    [ApiController]
    public class MsROApplicantRelationController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsROApplicantRelationRepositoryEF msROApplicantRepos;

        public MsROApplicantRelationController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.msROApplicantRepos = new MsROApplicantRelationRepositoryEF(_mastersContext);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetROApplicantRelation()
        {
            var roApplicant = await msROApplicantRepos.GetROApplicantRelationAsync();
            return Ok(roApplicant);
        }
    }
}