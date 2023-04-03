using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.OMA.Repositories.Interfaces
{
    public interface IOMA
    {
        Task<APIResponse> GetDetailById(string id);
        
    }
}
