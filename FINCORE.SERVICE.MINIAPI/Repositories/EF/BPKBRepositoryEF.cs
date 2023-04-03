using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.MINIAPI.Repositories.EF
{
    public class BPKBRepositoryEF : IBPKB
    {
        private AcquisitionContext acquisitionContext;
        private MastersContext mastappContext;
        public BPKBRepositoryEF(AcquisitionContext _acquisitionContext, MastersContext _mastapp_Context)
        {
            this.acquisitionContext = _acquisitionContext;
            this.mastappContext = _mastapp_Context; 
        }
        public async Task<APIResponse> GetBPKBLookupNPP(string? SearchTerm,string BranchID, int PageIndex, int PageSize, int? recordCount)
        {
            var _PageIndex = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?> { _value = PageIndex };
            var _PageSize = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = PageSize };
            var pagination = new Pagination<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKB_LookupResult>();
            var TotalPages = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?>();
            var RecordCount = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value=recordCount};
            try
            {
                List<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKB_LookupResult> result = await acquisitionContext.GetProcedures().sp_get_pagination_BPKB_LookupAsync(string.IsNullOrEmpty(SearchTerm)? "":SearchTerm,BranchID, _PageIndex, _PageSize, TotalPages, RecordCount);
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

        public async Task<APIResponse> GetBPKBPaging(string? SearchTerm, string BranchID, int PageIndex, int PageSize, int? recordCount)
        {
            var _PageIndex = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?> { _value = PageIndex };
            var _PageSize = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = PageSize };
            var pagination = new Pagination<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKB_expResult>();
            var TotalPages = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?>();
            var RecordCount = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = recordCount };
            try
            {
                List<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKB_expResult> result = await acquisitionContext.GetProcedures().sp_get_pagination_BPKB_expAsync(string.IsNullOrEmpty(SearchTerm) ? "" : SearchTerm, BranchID, _PageIndex, _PageSize, TotalPages, RecordCount);
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

        public async Task<APIResponse> GetBPKBPagingAsuransi(string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var _PageIndex = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?> { _value = PageIndex };
            var _PageSize = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = PageSize };
            var pagination = new Pagination<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKBAsuransiResult>();
            var TotalPages = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?>();
            var RecordCount = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = recordCount };
            try
            {
                List<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKBAsuransiResult> result = await acquisitionContext.GetProcedures().sp_get_pagination_BPKBAsuransiAsync(string.IsNullOrEmpty(SearchTerm) ? "" : SearchTerm, _PageIndex, _PageSize, TotalPages, RecordCount);
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

        public async Task<APIResponse> GetBPKBPagingBiroJasa(string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var _PageIndex = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?> { _value = PageIndex };
            var _PageSize = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = PageSize };
            var pagination = new Pagination<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKBBiroJasaResult>();
            var TotalPages = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?>();
            var RecordCount = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = recordCount };
            try
            {

                List<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKBBiroJasaResult> result = await acquisitionContext.GetProcedures().sp_get_pagination_BPKBBiroJasaAsync(string.IsNullOrEmpty(SearchTerm) ? "" : SearchTerm, _PageIndex, _PageSize, TotalPages, RecordCount);
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

        public async Task<APIResponse> GetBPKBPagingDealer(string? SearchTerm, string CreditID, int PageIndex, int PageSize, int? recordCount)
        {
            var _PageIndex = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?> { _value = PageIndex };
            var _PageSize = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = PageSize };
            var pagination = new Pagination<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKBDealerResult>();
            var TotalPages = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<int?>();
            var RecordCount = new LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext.OutputParameter<double?> { _value = recordCount };
            try
            {
                List<LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel.sp_get_pagination_BPKBDealerResult> result = await acquisitionContext.GetProcedures().sp_get_pagination_BPKBDealerAsync(string.IsNullOrEmpty(SearchTerm) ? "" : SearchTerm, CreditID, _PageIndex, _PageSize, TotalPages, RecordCount);
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

        

        public async Task<APIResponse> GetBPKBPagingTypeOfBureau(string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var _PageIndex = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<int?> { _value = PageIndex };
            var _PageSize = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<double?> { _value = PageSize };
            var pagination = new Pagination<sp_get_pagination_BPKBTypeOfBureauNecessityResult>();
            var TotalPages = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<int?>();
            var RecordCount = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<double?> { _value = recordCount };
            try
            {
                List<sp_get_pagination_BPKBTypeOfBureauNecessityResult> result = await mastappContext.GetProcedures().sp_get_pagination_BPKBTypeOfBureauNecessityAsync(string.IsNullOrEmpty(SearchTerm) ? "" : SearchTerm, _PageIndex, _PageSize, TotalPages, RecordCount);

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

        public async Task<APIResponse> GetBPKBReceiverLookup(string? SearchTerm, int PageIndex, int PageSize, int? recordCount)
        {
            var _PageIndex = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<int?> { _value = PageIndex };
            var _PageSize = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<double?> { _value = PageSize };
            var pagination = new Pagination<sp_get_pagination_BPKBReceiverResult>();
            var TotalPages = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<int?>();
            var RecordCount = new LIBRARY.DTO.EntityFramework.Masters.MastersContext.OutputParameter<double?> { _value = recordCount };
            try
            {
                List<sp_get_pagination_BPKBReceiverResult> result = await mastappContext.GetProcedures().sp_get_pagination_BPKBReceiverAsync(string.IsNullOrEmpty(SearchTerm) ? "" : SearchTerm, _PageIndex, _PageSize, TotalPages, RecordCount);
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
