using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories
{
    public class MsAgentMSRepository : IMasters
    {
        private readonly MastersContext mastersContext;

        public MsAgentMSRepository(MastersContext _mastersContext)
        {
            this.mastersContext = _mastersContext;
        }

        public Task<APIResponse> GetAllAsync()
        {
            throw new NotImplementedException();
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