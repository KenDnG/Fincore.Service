using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/dealer-personnel/")]
    [ApiController]
    public class MsDealerPersonnelController : ControllerBase
    {
        private readonly IMsDealerPersonnel iMsDealerPersonnel;

        public MsDealerPersonnelController(IMsDealerPersonnel _iMsDealerPersonnel)
        {
            this.iMsDealerPersonnel = _iMsDealerPersonnel;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllData()
        {
            return Ok(await iMsDealerPersonnel.GetAllDataAsync());
        }

        [HttpGet("byJobTitleId/{ID}")]
        public async Task<IActionResult> GetAllData(int ID)
        {
            return Ok(await iMsDealerPersonnel.GetListByCustomCondition(ID));
        }
    }
}