using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/profession")]
    [ApiController]
    public class MsProfessionController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsProfessionRepositoryEF msProfessionRepository;

        public MsProfessionController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.msProfessionRepository = new MsProfessionRepositoryEF(_mastersContext);
        }

        [HttpGet("getprofession")]
        public async Task<IActionResult> GetMsProfession()
        {
            var profession = await msProfessionRepository.GetProfessionAsync();
            return Ok(profession);
        }
    }
}