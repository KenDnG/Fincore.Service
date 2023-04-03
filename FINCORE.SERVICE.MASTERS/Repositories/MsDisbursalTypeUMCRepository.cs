using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsDisbursalTypeUMCRepository : IMasters
    {
        private readonly MastersContext mastersContext;

        public MsDisbursalTypeUMCRepository(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
        }

        public Task<APIResponse> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse> GetByIdAsync(string Id)
        {
            try
            {
                var data = await mastersContext.MsDisbursalTypeUmc
                                    .Where(x => x.BranchId == Id && x.IsActive == true).ToListAsync();

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