using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsSourceRepositoryEF : IMsSource
    {
        private MastersContext mastersContext;

        public MsSourceRepositoryEF(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
        }

        public async Task<APIResponse> GetSourceAsync()
        {
            try
            {
                var data = await mastersContext.GetProcedures().sp_get_sourceAsync();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
    }
}