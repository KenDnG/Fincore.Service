using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsIdentityTypeRepositoryEF : IMsIdentityType
    {
        private MastersContext masterContext;

        public MsIdentityTypeRepositoryEF(MastersContext masterContext)
        {
            this.masterContext = masterContext;
        }

        public async Task<APIResponse> GetIdentityTypeAsync()
        {
            try
            {
                var data = await masterContext.MsIdentityType
                                .Where(m => m.IsActive.Equals(true)).ToListAsync();
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

        public async Task<APIResponse> GetIdentityTypeAsync(string customerType)
        {
            try
            {
                var data = await masterContext.MsIdentityType
                                .Where(m => m.IsActive.Equals(true) && m.CustomerType.Contains(customerType))
                                .ToListAsync();
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