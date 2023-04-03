using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.OMA.Repositories.Interfaces;

namespace FINCORE.SERVICE.OMA.Repositories
{
    public class OMARepository : IOMA
    {
        private AcquisitionContext acquisitionContext;
        public OMARepository(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
        }
        public Task<APIResponse> GetDetailById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
