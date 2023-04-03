using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{

    public class MsBPKBReasonRepository : IMsBPKBReason
    {
        private MastersContext masterContext;

        public MsBPKBReasonRepository(MastersContext masterContext)
        {
            this.masterContext = masterContext;
        }

        public async Task<APIResponse> GetMsBPKBReason()
        {
            try
            {
                var data = this.masterContext.MsBpkbReason.Where(w => w.IsActive == true).ToList();

                return new APIResponse(Collection.Codes.SUCCESS, Collection.Status.SUCCESS, Collection.Messages.SUCCESS, data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR, Collection.Status.FAILED, ex.Message + ex.InnerException.Message, null);
            }
        }
    }
}
