using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsCreditSourceRepositoryEF : IMsCreditSource
    {
        private MastersContext masterContext;

        public MsCreditSourceRepositoryEF(MastersContext acquisitionContext)
        {
            this.masterContext = acquisitionContext;
        }

        public async Task<APIResponse> GetCreditSourceAsync()
        {
            try
            {
                var data = await masterContext.GetProcedures().sp_get_credit_sourceAsync();
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }
    }
}