using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;

namespace FINCORE.SERVICE.MINIAPI.Repositories.EF
{
    public class ApprovalRepository : IApproval
    {
        private readonly AcquisitionContext acquisitionContext;

        public ApprovalRepository(AcquisitionContext acquisitionContext)
        {
            this.acquisitionContext = acquisitionContext;
        }

        public async Task<APIResponse> GetPaginationInboxApproval(string? employeeId,string? searchTerm, 
            int pageIndex, int pageSize)
        {
            try
            {
                var data = new List<sp_get_pagination_approval_inboxResult>();
                var pagination = new Pagination<sp_get_pagination_approval_inboxResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<int?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> ();
                var _recCount = new OutputParameter<double?> ();

                data = await  acquisitionContext
                                .GetProcedures()
                                .sp_get_pagination_approval_inboxAsync(
                                    employeeId,
                                    searchTerm,
                                    _pageIndex, 
                                    _pageSize, 
                                    _totalPage,
                                    _recCount);

                pagination.SearchTerm = searchTerm;
                pagination.PageIndex = pageIndex;
                pagination.PageSize = _pageSize.Value ?? 10;
                pagination.TotalPages = _totalPage._value != null ? (int)_totalPage._value : 0;
                pagination.RecordCount = _recCount._value != null ? (int)_recCount._value : 0;
                pagination.Model = data;

                return new APIResponse(Collection.Codes.SUCCESS,
                                        Collection.Status.SUCCESS,
                                        Collection.Messages.SUCCESS, pagination);
                                  
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                                        Collection.Status.FAILED,
                                        ex.Message, new { }
                                        );
            }
        }
    }
}
