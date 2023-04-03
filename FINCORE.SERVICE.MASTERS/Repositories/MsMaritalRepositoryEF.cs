using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsMaritalRepositoryEF : IMsMarital
    {
        private MastersContext mastersContext;

        public MsMaritalRepositoryEF(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
        }

        public async Task<APIResponse> GetMaritalStatusAsync()
        {
            try
            {
                var data = await mastersContext.GetProcedures().sp_get_marital_statusAsync();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
    }
}