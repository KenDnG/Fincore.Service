using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsPromotionLineTextRepository : IMasters
    {
        private readonly MastersContext mastersContext;

        public MsPromotionLineTextRepository(MastersContext mastersContext)
        {
            this.mastersContext = mastersContext;
        }

        public async Task<APIResponse> GetAllAsync()
        {
            try
            {
                var data = await mastersContext.MsPromotionLineText
                    .Where(x => x.IsActive)
                    .ToListAsync();

                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                            Collection.Status.FAILED,
                                            $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                                            null);
            }
        }

        public async Task<APIResponse> GetSingleAsync()
        {
            try
            {
                var data = await mastersContext.MsPromotionLineText
                    .Where(x => x.IsActive)
                    .FirstAsync();

                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                            Collection.Status.FAILED,
                                            $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                                            null);
            }
        }

        public Task<APIResponse> GetByIdAsync(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> InsertAsync(object obj)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse> UpdateAsync(string Id, object obj)
        {
            throw new NotImplementedException();
        }
    }
}