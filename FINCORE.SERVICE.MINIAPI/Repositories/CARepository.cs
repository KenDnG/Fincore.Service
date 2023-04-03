using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces.Credit_Analyst;

namespace FINCORE.SERVICE.MINIAPI.Repositories
{
    public class CARepository : ICA
    {
        private AcquisitionContext acquisitionContext;

        public CARepository(AcquisitionContext _acquisitionContext)
        {
            this.acquisitionContext = _acquisitionContext;
        }

        public async Task<APIResponse> GetCAPagingLookupApprovalScheme(string BranchID, string TransTypeId, string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var data = new List<sp_get_paging_approvalschemeResult>();
            var pagination = new Pagination<sp_get_paging_approvalschemeResult>();
            var TotalPages = new OutputParameter<int?>();
            var RecordCount = new OutputParameter<int?>();
            try
            {
                List<sp_get_paging_approvalschemeResult> result = await acquisitionContext.GetProcedures().sp_get_paging_approvalschemeAsync(BranchID, TransTypeId, SearchTerm == null ? "" : SearchTerm, PageIndex, PageSize, TotalPages, RecordCount);
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
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetCAApprovalScheme(string BranchID, string TransTypeId)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_approval_schemeAsync(BranchID, TransTypeId));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetCAApprovalUser(string ApprovalSchemeID, string ApprovalLevelDesc)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_approval_userAsync(ApprovalSchemeID, ApprovalLevelDesc));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetCAListPagination(string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var data = new List<sp_get_pagination_caResult>();
            var pagination = new Pagination<sp_get_pagination_caResult>();
            var TotalPages = new OutputParameter<int?>();
            var RecordCount = new OutputParameter<int?>();
            try
            {
                List<sp_get_pagination_caResult> result = await acquisitionContext.GetProcedures().sp_get_pagination_caAsync(SearchTerm == null ? "" : SearchTerm, PageIndex, PageSize, TotalPages, RecordCount);
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
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetCALookupHistory(string CANo, string TransTypeId)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_pagination_CA_Lookup_HistoryAsync(CANo, TransTypeId));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetCALookupViewDokumen(string Id, string PhotoTypeID)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_foto_caAsync(Id, PhotoTypeID));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetFCLId(string CASId)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_fclidAsync(CASId));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetFCLHeaderSLIK(string fclid)
        {
            try
            {
                return new APIResponse(Collection.Codes.SUCCESS,
                        Collection.Status.SUCCESS,
                        Collection.Messages.SUCCESS,
                        await acquisitionContext.GetProcedures().sp_get_fcl_result_header_slikAsync(fclid));
            }
            catch (Exception ex)
            {
                return new APIResponse(Collection.Codes.INTERNAL_SERVER_ERROR,
                        Collection.Status.FAILED,
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetFCLSummarySLIK(string fclid, string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var data = new List<sp_get_fcl_result_summary_slikResult>();
            var pagination = new Pagination<sp_get_fcl_result_summary_slikResult>();
            var TotalPages = new OutputParameter<int?>();
            var RecordCount = new OutputParameter<int?>();
            try
            {
                List<sp_get_fcl_result_summary_slikResult> result = await acquisitionContext.GetProcedures().sp_get_fcl_result_summary_slikAsync(fclid, SearchTerm == null ? "" : SearchTerm, PageIndex, PageSize, TotalPages, RecordCount);
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
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetFCLHistoryKolSLIK(string fclid, string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var data = new List<sp_get_fcl_result_history_kol_slikResult>();
            var pagination = new Pagination<sp_get_fcl_result_history_kol_slikResult>();
            var TotalPages = new OutputParameter<int?>();
            var RecordCount = new OutputParameter<int?>();
            try
            {
                List<sp_get_fcl_result_history_kol_slikResult> result = await acquisitionContext.GetProcedures().sp_get_fcl_result_history_kol_slikAsync(fclid, SearchTerm == null ? "" : SearchTerm, PageIndex, PageSize, TotalPages, RecordCount);
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
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetFCLDetailKreditSLIK(string fclid, string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var data = new List<sp_get_fcl_result_detail_kredit_slikResult>();
            var pagination = new Pagination<sp_get_fcl_result_detail_kredit_slikResult>();
            var TotalPages = new OutputParameter<int?>();
            var RecordCount = new OutputParameter<int?>();
            try
            {
                List<sp_get_fcl_result_detail_kredit_slikResult> result = await acquisitionContext.GetProcedures().sp_get_fcl_result_detail_kredit_slikAsync(fclid, SearchTerm == null ? "" : SearchTerm, PageIndex, PageSize, TotalPages, RecordCount);
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
                        ex.Message,
                        null);
            }
        }

        public async Task<APIResponse> GetFCLDetailKonsumenSLIK(string fclid, string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var data = new List<sp_get_fcl_result_detail_konsumen_slikResult>();
            var pagination = new Pagination<sp_get_fcl_result_detail_konsumen_slikResult>();
            var TotalPages = new OutputParameter<int?>();
            var RecordCount = new OutputParameter<int?>();
            try
            {
                List<sp_get_fcl_result_detail_konsumen_slikResult> result = await acquisitionContext.GetProcedures().sp_get_fcl_result_detail_konsumen_slikAsync(fclid, SearchTerm == null ? "" : SearchTerm, PageIndex, PageSize, TotalPages, RecordCount);
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
                        ex.Message,
                        null);
            }
        }
    }
}