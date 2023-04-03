using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.SERVICE.NPP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.NPP.Repositories
{
    public class TrDealerOrderSourceThirdPartyRepository : ITrDealerOrderSourceThirdParty
    {
        private readonly AcquisitionContext acquisitionContext;

        public TrDealerOrderSourceThirdPartyRepository(AcquisitionContext acquisitionContext)
        {
            this.acquisitionContext = acquisitionContext;
        }

        public async Task<APIResponse> GetManipulateDataByCreditId(string creditId)
        {
            try
            {
                var data = await acquisitionContext.GetProcedures().sp_get_data_order_source_TPAsync(creditId);

                return new APIResponse(data);
            }
            catch (Exception ex)
            {
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        null
                    );
            }
        }

        public async Task<APIResponse> GetRealDataByCreditId(string creditId)
        {
            try
            {
                var nppData = await acquisitionContext.TrDealerOrderSourceThirdParty
                    .Where(x => x.CreditId == creditId)
                    .ToListAsync();

                return new APIResponse(nppData);
            }
            catch (Exception ex)
            {
                return new APIResponse
                    (
                        Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                        null
                    );
            }
        }
    }
}