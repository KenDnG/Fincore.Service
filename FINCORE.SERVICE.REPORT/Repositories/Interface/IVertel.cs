using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.REPORT.Repositories.Interface
{
    public interface IVertel
    {
        Task<APIResponse> PrintVerificationCustomer(string transId, string employeeId, string sessBranchId);
        Task<APIResponse> PrintVerificationCustomerDokumen(string transId);
    }
}
