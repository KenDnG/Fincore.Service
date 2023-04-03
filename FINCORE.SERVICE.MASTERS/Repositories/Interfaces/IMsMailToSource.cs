using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsMailToSource
    {
        Task<APIResponse> GetMailToSourceAsync();

        Task<APIResponse> GetMailToSourceByIdAsync(int id);
    }
}