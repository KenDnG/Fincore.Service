using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.SERVICE.CREDITS.Repositories.Interfaces;

namespace FINCORE.SERVICE.CREDITS.Repositories.EF
{
    public class AcquisitionRepository : IAcquisition
    {
        public readonly AcquisitionContext acquisitionContext;

        public AcquisitionRepository(AcquisitionContext acquisitionContext)
                        => this.acquisitionContext = acquisitionContext;

        public async Task<APIResponse> CheckUserPositionPrintPO(string employeeId)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures().sp_get_check_user_print_poAsync(employeeId);
                return new APIResponse(Collection.Codes.SUCCESS,
                            Collection.Status.SUCCESS,
                            Collection.Messages.SUCCESS,
                            data);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                    Collection.Status.FAILED,
                                    ex.Message, null);
            }
        }

        public async Task<APIResponse> GetPONumberByCreditIdAsync(string creditId)
        {
            try
            {
                var data = acquisitionContext.TrPo
                            .Where(m => m.CreditId.Equals(creditId))
                            .ToList();
                return new APIResponse(Collection.Codes.SUCCESS,
                                    Collection.Status.SUCCESS,
                                    Collection.Messages.SUCCESS,
                                    data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message);
            }
        }

        public async Task<APIResponse> InsertTrPOSendEmailAsync(TrPoSendToEmail trPoSendToEmail)
        {
            try
            {
                await acquisitionContext.TrPoSendToEmail.AddAsync(trPoSendToEmail);
                await acquisitionContext.SaveChangesAsync();

                return new APIResponse(Collection.Codes.CREATED,
                            Collection.Status.SUCCESS,
                            $"Pdf file created. Detail: {trPoSendToEmail.FileName}",
                            null);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"Failed insert into table TrPOSendToEmail. Error: {ex.Message}",
                        null);
            }
        }

        public async Task<APIResponse> OpenCM(string poNo, string creditId)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures().sp_trans_open_cmAsync(poNo, creditId);
                return new APIResponse(Collection.Codes.SUCCESS,
                            Collection.Status.SUCCESS,
                            $"Berhasil melakukan Open CM pada Credit ID: {creditId}",
                            null);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                            Collection.Status.FAILED,
                            $"Gagal melakukan Open CM. Exception Error: {ex.Message}", null);
            }
        }

        public async Task<APIResponse> SendEmailPrintPO(string poNo)
        {
            try
            {
                var data = await acquisitionContext
                    .GetProcedures()
                    .sp_send_email_print_POAsync(poNo);

                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }

        public async Task<APIResponse> UpdateSumPrintPO(string poNo, string printBy)
        {
            try
            {
                var existingData = acquisitionContext.TrPo.Where(m => m.PoNo.Equals(poNo)).ToList().First();
                if (existingData.SumOfPrint is 0)
                {
                    existingData.FirstPrintBy = printBy;
                    existingData.FirstPrintDate = DateTime.Now;
                }
                existingData.SumOfPrint += 1;
                existingData.IsPrint = true;
                existingData.LastPrintBy = printBy;
                existingData.StatusPo = "L";
                existingData.LastPrintDate = DateTime.Now;
                existingData.LastUpdatedOn = DateTime.Now;
                existingData.LastUpdatedBy = printBy;
                await acquisitionContext.SaveChangesAsync();

                return new APIResponse(Collection.Codes.SUCCESS,
                            Collection.Status.SUCCESS,
                            $"Updating Sum Of Print into PO:{poNo}",
                            null);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
    }
}