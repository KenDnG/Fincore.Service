using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsROCategory
    {
        Task<APIResponse> GetROCategoryAsync();
    }
}