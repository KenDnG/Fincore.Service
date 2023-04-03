using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMSMenu
    {
        Task<APIResponse> GetMenuTree(string NIK);
    }
}