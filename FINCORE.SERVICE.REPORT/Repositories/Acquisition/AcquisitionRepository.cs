using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.REPORT.Repositories.Interface;

namespace FINCORE.SERVICE.REPORT.Repositories.Acquisition
{
    public class AcquisitionRepository : IAcquisition
    {
        private AcquisitionContext acquisitionContext;

        public AcquisitionRepository(AcquisitionContext acquisitionContext) => this.acquisitionContext = acquisitionContext;

        public async Task<APIResponse> PrintPOMobilAsync(string poNo, string branchId, string userId)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures()
                                .sp_print_po_acquisition_mobilAsync(poNo, branchId, userId);
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }

        public async Task<APIResponse> PrintPOMotorAsync(string poNo, string branchId, string userId)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures()
                                .sp_print_po_acquisition_motorAsync(poNo, branchId, userId);
                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse(ex.Message, null);
            }
        }
    }
}