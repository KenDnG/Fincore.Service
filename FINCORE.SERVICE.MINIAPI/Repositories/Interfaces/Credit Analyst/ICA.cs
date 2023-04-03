using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MINIAPI.Repositories.Interfaces.Credit_Analyst
{
    public interface ICA
    {
        Task<APIResponse> GetCAListPagination(string? SearchTerm, int PageIndex
                                 , int PageSize, int? RecordCount);

        Task<APIResponse> GetCALookupHistory(string CANo, string TransTypeId);

        Task<APIResponse> GetCALookupViewDokumen(string Id, string PhotoTypeID);

        Task<APIResponse> GetCAPagingLookupApprovalScheme(string BranchID, string TransTypeId, string? SearchTerm, int PageIndex
                                 , int PageSize, int? RecordCount);

        Task<APIResponse> GetCAApprovalScheme(string BranchID, string TransTypeId);

        Task<APIResponse> GetCAApprovalUser(string ApprovalSchemeID, string ApprovalLevelDesc);

        //Slik
        Task<APIResponse> GetFCLId(string CASId);

        Task<APIResponse> GetFCLHeaderSLIK(string fclid);

        Task<APIResponse> GetFCLSummarySLIK(string fclid, string? SearchTerm, int PageIndex, int PageSize, int? recordCount);

        Task<APIResponse> GetFCLHistoryKolSLIK(string fclid, string? SearchTerm, int PageIndex, int PageSize, int? recordCount);

        Task<APIResponse> GetFCLDetailKreditSLIK(string fclid, string? SearchTerm, int PageIndex, int PageSize, int? recordCount);

        Task<APIResponse> GetFCLDetailKonsumenSLIK(string fclid, string? SearchTerm, int PageIndex, int PageSize, int? recordCount);
    }
}