using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsCustomerTypeRepositoryEF : IMsCustomerType
    {
        private MastersContext mastersContext;

        public MsCustomerTypeRepositoryEF(MastersContext _mastersContext)
            => this.mastersContext = _mastersContext;

        public async Task<APIResponse> GetCustomerTypeAsync()
        {
            try
            {
                var data = await mastersContext.GetProcedures().sp_get_customer_typeAsync();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
    }
}