using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.REPORT.Repositories.Interface
{
    public interface INPP
    {
        Task<APIResponse> PrintMemorandumOfUnderstanding(string creditId);
        Task<APIResponse> PrintImportantNotice(string creditId);
        Task<APIResponse> PrintPowerOfAttorneyFidusia(string creditId);
        Task<APIResponse> PrintPowerOfAttorney(string creditId);
        Task<APIResponse> PrintStatementLetter(string creditId);

        Task<APIResponse> PrintSecondStatementLetter(string creditId);

        Task<APIResponse> PrintConsumentStatementLetter(string creditId);

        Task<APIResponse> PrintNameChangeStatementLetter(string creditId);
        Task<APIResponse> PrintNameChangeReceipt(string creditId);    


    }
}