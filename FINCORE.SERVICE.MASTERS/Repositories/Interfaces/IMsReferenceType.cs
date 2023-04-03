using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsReferenceType
    {
        Task<APIResponse> GetReferenceType();

        Task<APIResponse> GetReferenceTypeByRefName();
    }
}