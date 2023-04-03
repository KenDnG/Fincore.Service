using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/company_branch/")]
    [ApiController]
    public class msCompanyBranch : ControllerBase
    {
        private readonly IMSCompanyBranch mSCompanyBranch;

        public msCompanyBranch(IMSCompanyBranch mSCompanyBranch)
        {
            this.mSCompanyBranch = mSCompanyBranch;
        }

        [HttpGet("ef/getCompanyBranch")]
        public async Task<IActionResult> Get(string company_id, string NIK)
        {
            var data = await mSCompanyBranch.GetCompanyBranch(company_id, NIK);
            return Ok(data);
        }
        [HttpGet("ef/GetBranchDetail")]
        public async Task<IActionResult> GetBranchDetail(string branch_id)
        {
            var data = await mSCompanyBranch.GetBranchDetail(branch_id);
            return Ok(data);
        }
    }
}