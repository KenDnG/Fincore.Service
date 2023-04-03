using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MINIAPI.Repositories.Interfaces
{
    public interface IAcquisition
    {
        Task<APIResponse> GetPaginationAcquisitionMobil(string branch_id, string? searchTerm, int pageIndex, double pageSize, int? totalPage, double? recCount);

        Task<APIResponse> GetPaginationAcquisitionMotor(string branch_id, string? searchTerm, string? searchTerm1, int pageIndex, double pageSize, int? totalPage, double? recCount);
        Task<APIResponse> GetPaginationNikKonsumen(string? employeeName, string? branchId, bool isKonsol, bool includePos, int pageIndex, double pageSize, int? totalPage, double? recCount);
    }
}