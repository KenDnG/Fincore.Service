using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MINIAPI.Repositories.Interfaces
{
    public interface INPPMenu
    {
        Task<APIResponse> GetPaginationNPPs(string? searchTerm, int pageIndex, int pageSize, int? totalPage, int? recCount);

        Task<APIResponse> GetPaginationDealerBankAccount(string? searchTerm, int pageIndex, int pageSize, int? totalPage, int? recCount);
    }
}