using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsDealerPersonnel
    {
        Task<APIResponse> GetAllDataAsync();

        Task<APIResponse> GetListByCustomCondition(int param);
    }
}