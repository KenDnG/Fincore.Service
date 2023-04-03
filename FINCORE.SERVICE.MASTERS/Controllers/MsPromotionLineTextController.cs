using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/promotion-line-text/")]
    [ApiController]
    public class MsPromotionLineTextController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsPromotionLineTextRepository repository;

        public MsPromotionLineTextController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.repository = new MsPromotionLineTextRepository(this.mastersContext);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllPromotionLineText()
        {
            return Ok(await repository.GetAllAsync());
        }

        [HttpGet("single")]
        public async Task<IActionResult> GetSinglePromotionLineText()
        {
            return Ok(await repository.GetSingleAsync());
        }
    }
}