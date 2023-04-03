using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels;
using FINCORE.SERVICE.MASTERS.Repositories.Interfaces;

namespace FINCORE.SERVICE.MASTERS.Repositories.EF
{
    public class MsBPKBReceiverRepository:IMsBPKBReceiver
    {
        private MastersContext masterContext;

        public MsBPKBReceiverRepository(MastersContext masterContext)
        {
            this.masterContext = masterContext;
        }

        public async Task<APIResponse> GetBPKBReceiverLookup(string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var _PageIndex = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<int?> { _value = PageIndex };
            var _PageSize = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<double?> { _value = PageSize };
            var pagination = new Pagination<sp_get_pagination_BPKBReceiverResult>();
            var TotalPages = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<int?>();
            var RecordCount = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<double?> { _value = recordCount };
            try
            {
                List<sp_get_pagination_BPKBReceiverResult> result = await masterContext.GetProcedures().sp_get_pagination_BPKBReceiverAsync(string.IsNullOrEmpty(SearchTerm) ? "" : SearchTerm, _PageIndex, _PageSize, TotalPages, RecordCount);
                pagination.TotalPages = Convert.ToInt32(TotalPages.Value);
                pagination.RecordCount = Convert.ToInt32(RecordCount.Value);
                pagination.Model = result;
                pagination.SearchTerm = SearchTerm;
                pagination.PageIndex = PageIndex;
                pagination.PageSize = PageSize;

                return new APIResponse(Collection.Codes.SUCCESS,
                    Collection.Status.SUCCESS,
                    Collection.Messages.SUCCESS,
                    pagination);
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                       Collection.Status.FAILED,
                       ex.Message + ex.InnerException.Message,
                       null);
            }
        }
    }
}
