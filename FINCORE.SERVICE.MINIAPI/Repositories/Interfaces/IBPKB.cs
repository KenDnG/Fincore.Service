using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MINIAPI.Repositories.Interfaces
{
    public interface IBPKB
    {
        Task<APIResponse> GetBPKBLookupNPP(string? SearchTerm,string BranchID, int PageIndex, int PageSize, int? RecordCount);
        Task<APIResponse> GetBPKBReceiverLookup(string? SearchTerm, int PageIndex
                                , int PageSize, int? RecordCount);
        Task<APIResponse> GetBPKBPaging(string? SearchTerm, string BranchID, int PageIndex, int PageSize, int? RecordCount);
        Task<APIResponse> GetBPKBPagingTypeOfBureau(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount);
        Task<APIResponse> GetBPKBPagingDealer(string? SearchTerm, string CreditID, int PageIndex, int PageSize, int? RecordCount);
        Task<APIResponse> GetBPKBPagingAsuransi(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount);
        Task<APIResponse> GetBPKBPagingBiroJasa(string? SearchTerm, int PageIndex, int PageSize, int? RecordCount);
    }
}
