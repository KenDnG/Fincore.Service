using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.EF;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.MASTERS.Controllers
{
    [Route("api/v1/services/master/relationship")]
    [ApiController]
    public class MsRelationshipController : ControllerBase
    {
        private readonly MastersContext mastersContext;
        private readonly MsRelationshipRepositoryEF msRelationshipRepository;

        public MsRelationshipController(MastersContext mastersContext)
        {
            this.mastersContext = mastersContext;
            this.msRelationshipRepository = new MsRelationshipRepositoryEF(mastersContext);
        }

        [HttpGet("ef/getrelationship")]
        public async Task<IActionResult> GetRelationship()
        {
            var relationship = await msRelationshipRepository.GetRelationshipAsync();
            return Ok(relationship);
        }
    }
}