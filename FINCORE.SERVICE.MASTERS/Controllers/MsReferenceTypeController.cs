using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/referencetype")]
    [ApiController]
    public class MsReferenceTypeController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsReferenceTypeRepositoryEF msReferenceTypeRepository;

        public MsReferenceTypeController(MastersContext mastersContext)
        {
            this.mastersContext = mastersContext;
            this.msReferenceTypeRepository = new MsReferenceTypeRepositoryEF(mastersContext);
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetMsReferenceType()
        {
            var referenceType = await msReferenceTypeRepository.GetReferenceType();
            return Ok(referenceType);
        }

        [HttpGet("getrefname")]
        public async Task<IActionResult> GetMsReferenceType_Refname()
        {
            var referenceType = await msReferenceTypeRepository.GetReferenceTypeByRefName();
            return Ok(referenceType);
        }
    }
}