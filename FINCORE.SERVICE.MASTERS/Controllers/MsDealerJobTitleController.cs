using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/dealer-job-title/")]
    [ApiController]
    public class MsDealerJobTitleController : ControllerBase
    {
        private readonly IMsDealerJobTitle msDealerJobTitle;

        public MsDealerJobTitleController(IMsDealerJobTitle _iMsDealerJobTitle)
        {
            this.msDealerJobTitle = _iMsDealerJobTitle;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllDealerJobTitleInterface()
        {
            return Ok(await msDealerJobTitle.GetAllDataAsync());
        }

        [HttpGet("byId/{ID}")]
        public async Task<IActionResult> GetAllDealerJobTitleRepo(int ID)
        {
            return Ok(await msDealerJobTitle.GetListByCustomCondition(ID));
        }
    }
}