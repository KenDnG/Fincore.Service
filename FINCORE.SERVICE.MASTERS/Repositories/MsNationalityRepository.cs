using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsNationalityRepository : IMsNationality
    {
        private MastersContext masterContext;

        public MsNationalityRepository(MastersContext masterContext)
        {
            this.masterContext = masterContext;
        }

        public async Task<APIResponse> GetNationalityAsync()
        {
            try
            {
                var data = await masterContext.MsNationality
                                                .Where(m => m.IsActive.Equals(true))
                                                .ToListAsync();
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
    }
}