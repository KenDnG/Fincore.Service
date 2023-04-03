using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsDealerJobTitle
    {
        Task<APIResponse> GetAllDataAsync();

        Task<APIResponse> GetListByCustomCondition(int param);
    }
}