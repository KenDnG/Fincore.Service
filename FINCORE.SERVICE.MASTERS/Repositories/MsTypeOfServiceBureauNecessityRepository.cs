using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsTypeOfServiceBureauNecessityRepository : IMsTypeOfServiceBureauNecessity
    {
        private MastersContext masterContext;

        public MsTypeOfServiceBureauNecessityRepository(MastersContext masterContext)
        {
            this.masterContext = masterContext;
        }
        public async Task<APIResponse> GetTypeOfService()
        {
            try
            {
                var data = this.masterContext.MsTypeOfServiceBureauNecessity.Where(w => w.IsActive == true).ToList();

                return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, ex.Message + ex.InnerException.Message, null);
            }
        }
    }
}
