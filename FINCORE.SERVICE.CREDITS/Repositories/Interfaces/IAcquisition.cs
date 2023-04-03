using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;

namespace FINCORE.SERVICE.CREDITS.Repositories.Interfaces
{
    public interface IAcquisition
    {
        Task<APIResponse> GetPONumberByCreditIdAsync(string creditId);

        Task<APIResponse> InsertTrPOSendEmailAsync(TrPoSendToEmail trPoSendToEmail);

        Task<APIResponse> SendEmailPrintPO(string poNo);

        Task<APIResponse> UpdateSumPrintPO(string poNo, string printBy);

        Task<APIResponse> OpenCM(string poNo, string creditId);

        /// <summary>
        /// Check NIK user yang bisa melakukan Print PO
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        Task<APIResponse> CheckUserPositionPrintPO(string employeeId);
    }
}