using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.REPORT.Repositories.Interface;

namespace FINCORE.SERVICE.REPORT.Repositories.Acquisition
{
    public class VertelRepository : IVertel
    {
        private AcquisitionContext acquisitionContext;

        public VertelRepository(AcquisitionContext acquisitionContext)
        {
            this.acquisitionContext = acquisitionContext;
        }

        public async Task<APIResponse> PrintVerificationCustomer(string transId, string employeeId, string sessBranchId)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures().sp_print_vertelAsync(transId,employeeId,sessBranchId);
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }

        public async Task<APIResponse> PrintVerificationCustomerDokumen(string transId)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                         await acquisitionContext.GetProcedures().sp_print_vertel_dokumen_inAsync(transId));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }

        }
    }
}
    