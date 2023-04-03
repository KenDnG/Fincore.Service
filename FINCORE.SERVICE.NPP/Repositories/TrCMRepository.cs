using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.SERVICE.NPP.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.NPP.Repositories
{
    public class TrCMRepository : ITrCM
    {
        private AcquisitionContext acquisitionContext;

        public TrCMRepository(AcquisitionContext _context)
        {
            this.acquisitionContext = _context;
        }

        public async Task<TrCm> GetCMByCreditId(string creditId)
        {
            TrCm data = new TrCm();
            try
            {
                data = await acquisitionContext.TrCm
                    .SingleAsync(d => d.CreditId.Equals(creditId));

                return data;
            }
            catch (Exception ex)
            {
                return data;
            }
        }

        public async Task<APIResponse> GetProcessCMByCreditId(string creditId)
        {
            try
            {
                var cm = await acquisitionContext.GetProcedures().sp_get_data_process_cmAsync(creditId);
                //var data = acquisitionContext.TrCm
                //                .Join(
                //                    mastersContext.MsDealer,
                //                    cm => cm.DealerCode,
                //                    dealer => dealer.DealerCode,
                //                    (cm, dealer) => new {
                //                        })
                //                .Single(cmDatas => cmDatas.cm.CreditId == creditId);

                //var asas = acquisitionContext.TrCm.Where(a => a.CreditId == creditId);

                if (cm[0] != null)
                {
                    return new APIResponse(cm[0]);
                }

                return new APIResponse(Collection.Codes.NO_CONTENT,
                                        Collection.Status.SUCCESS,
                                        Collection.Messages.NO_CONTENT,
                                        null);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                        Collection.Status.FAILED,
                                        $"{ex.Message}. {Collection.Messages.INTERNAL_SERVER_ERROR}",
                                        null);
            }
        }
    }
}