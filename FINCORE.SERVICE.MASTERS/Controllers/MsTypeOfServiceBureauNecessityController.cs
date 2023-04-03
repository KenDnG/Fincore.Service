using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;


namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/TypeOfServiceBureauNecessity/")]
    [ApiController]
    public class MsTypeOfServiceBureauNecessityController:ControllerBase
    {
        private MastersContext mastersContext;
        private readonly MsTypeOfServiceBureauNecessityRepository repository;
        public MsTypeOfServiceBureauNecessityController(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
            this.repository = new MsTypeOfServiceBureauNecessityRepository(mastersContext);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetTypeOfServiceBureauNecessity()
        {
            return Ok(await repository.GetTypeOfService());
        }
    }
}
