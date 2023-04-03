using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MINIAPI.Repositories.Interfaces
{
    public interface IApproval
    {
        Task<APIResponse> GetPaginationInboxApproval(string? employeeId, string? searchTerm,
            int pageIndex, int pageSize);
    }
}
