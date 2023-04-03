using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMasters
    {
        Task<APIResponse> GetAllAsync();

        Task<APIResponse> GetByIdAsync(string Id);

        Task<APIResponse> GetByIdAsync(int Id);

        Task<APIResponse> InsertAsync(object obj);

        Task<APIResponse> UpdateAsync(string Id, object obj);
    }
}