using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MINIAPI.Repositories.Interfaces
{
    public interface ITrCas
    {
        Task<APIResponse> GetPaginationLocations(string? searchTerm, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationBank(string? searchTerm, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationPoolingOrder(string tipeOrder, string branchId, string? searchTerm, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationAgreementOld(string? searchTerm, string LesseeId, int pageIndex, double pageSize, int? totalPage, double? recCount);
    }
}