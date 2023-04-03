using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/rocategory")]
    [ApiController]
    public class MsROCategoryController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsROCategoryRepositoryEF msROCategoryRepo;

        public MsROCategoryController(MastersContext _masterContext)
        {
            this.mastersContext = _masterContext;
            this.msROCategoryRepo = new MsROCategoryRepositoryEF(_masterContext);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetMsROCategory()
        {
            var roCategory = await msROCategoryRepo.GetROCategoryAsync();
            return Ok(roCategory);
        }
    }
}