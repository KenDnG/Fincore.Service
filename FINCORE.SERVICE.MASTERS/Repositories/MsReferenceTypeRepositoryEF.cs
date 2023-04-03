using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsReferenceTypeRepositoryEF : IMsReferenceType
    {
        private MastersContext mastersContext;

        public MsReferenceTypeRepositoryEF(MastersContext _mastersContext)
            => this.mastersContext = _mastersContext;

        public async Task<APIResponse> GetReferenceType()
        {
            try
            {
                var data = mastersContext.MsReferenceType
                                                .Where(m => m.IsActive.Equals(true))
                                                .ToList();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }

        public async Task<APIResponse> GetReferenceTypeByRefName()
        {
            try
            {
                var data = await mastersContext.GetProcedures().sp_get_msreferencetype_refnameAsync();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
    }
}