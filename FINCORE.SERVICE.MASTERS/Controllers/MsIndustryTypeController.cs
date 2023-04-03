using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/industrytype")]
    [ApiController]
    public class MsIndustryTypeController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsIndustryTypeRepositoryEF msIndustryTypeRepository;

        public MsIndustryTypeController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.msIndustryTypeRepository = new MsIndustryTypeRepositoryEF(mastersContext);
        }

        [HttpGet("getindustrytype")]
        public async Task<IActionResult> GetMsIndustryType()
        {
            var industry = await msIndustryTypeRepository.GetIndustryTypeAsync();
            return Ok(industry);
        }
    }
}