using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MINIAPI.Repositories.Interfaces.CM
{
    public interface ICM
    {
        Task<APIResponse> GetPaginationItem(string? searchTerm, string? item_id, string? item_brand_id, string? asset_kind_class_id, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationDealer(string? searchTerm, string? item_id, string? is_item_new, string? branch_id, string? item_merk, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationSurveyor(string? searchTerm, string? item_id, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationMarketingHead(string? searchTerm, string? item_id, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationCGSNo(string? searchTerm, string? BranchId, string? CompanyId, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationOldNPP(string? searchTerm, string? BranchId, string? CompanyId, string ItemMerkTypeID, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationPerantara(string? searchTerm, string? BranchId, string? CompanyId, string TipePerantara, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationBankName(string? searchTerm, string? BranchId, string? CompanyId, string PemilikRekening, int pageIndex, double pageSize, int? totalPage, double? recCount);
    }
}