using FINCORE.HELPER.LIBRARY.DbAccess;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.OMA.DbContexts;
using FINCORE.SERVICE.OMA.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FINCORE.SERVICE.OMA.Controllers
{
    [Route("api/v0/services/acquisition/BPKB/")]
    [ApiController]
    public class OMAController : ControllerBase
    {
        private ConnectionConfigServices connectionConfigServices = new ConnectionConfigServices();
        private AcquisitionContext dbContext;
        private OMARepository OMARepository;

        private DbContext dbContextADO;
        public OMAController(AcquisitionContext _db, MastersContext _ma)
        {
            try
            {
                this.dbContext = _db;
                this.OMARepository = new OMARepository(_db);

                this.dbContextADO = new DbContext(this.connectionConfigServices.GetConnection(connectionConfigServices.GetConnAcquisition()));

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("OMA/[Action]")]
        public async Task<IActionResult> GetDetailById(string Id)
        {
            return Ok(await OMARepository.GetDetailById(Id));
        }



        
    }
}
