using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;

namespace FINCORE.SERVICE.MINIAPI.Repositories.EF.Acquisition.CAS
{
    public class TrCasRepositoryEF : ITrCas
    {
        private AcquisitionContext acquisitionContext;

        public TrCasRepositoryEF(AcquisitionContext acquisitionContext)
        {
            this.acquisitionContext = acquisitionContext;
        }

        public async Task<APIResponse> GetPaginationAgreementOld(string? searchTerm, string lesseeId, int pageIndex, double pageSize, int? totalPage, double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_agreement_oldResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_agreement_oldResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_agreement_oldAsync(searchTerm, lesseeId, _pageIndex
                                                                                                , _pageSize, _totalPage, _recCount);
                pagination.SearchTerm = searchTerm;
                pagination.PageIndex = (int)_pageIndex.Value;
                pagination.PageSize = (int)_pageSize.Value;
                pagination.TotalPages = _totalPage._value != null ? (int)_totalPage._value : 0;
                pagination.RecordCount = _recCount._value != null ? (int)_recCount._value : 0;
                pagination.Model = data;

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

        public async Task<APIResponse> GetPaginationBank(string? searchTerm, int pageIndex, double pageSize, int? totalPage, double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_msbankResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_msbankResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_msbankAsync(searchTerm, _pageIndex, _pageSize,
                                                                                                    _totalPage, _recCount);
                pagination.SearchTerm = searchTerm;
                pagination.PageIndex = (int)_pageIndex.Value;
                pagination.PageSize = (int)_pageSize.Value;
                pagination.TotalPages = _totalPage._value != null ? (int)_totalPage._value : 0;
                pagination.RecordCount = _recCount._value != null ? (int)_recCount._value : 0;
                pagination.Model = data;

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

        public async Task<APIResponse> GetPaginationLocations(string? searchTerm, int pageIndex,
                                                                                double pageSize,
                                                                                int? totalPage,
                                                                                double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_locationResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_locationResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_locationAsync(searchTerm, _pageIndex, _pageSize,
                                                                                                    _totalPage, _recCount);
                pagination.SearchTerm = searchTerm;
                pagination.PageIndex = (int)_pageIndex.Value;
                pagination.PageSize = (int)_pageSize.Value;
                pagination.TotalPages = _totalPage._value != null ? (int)_totalPage._value : 0;
                pagination.RecordCount = _recCount._value != null ? (int)_recCount._value : 0;
                pagination.Model = data;

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

        public async Task<APIResponse> GetPaginationPoolingOrder(string? tipeOrder, string? branchId, string? searchTerm, int pageIndex, double pageSize, int? totalPage, double? recCount)
        {
            try
            {
                var data = new List<sp_pagination_lookup_orderidResult>();
                var pagination = new Pagination<sp_pagination_lookup_orderidResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_pagination_lookup_orderidAsync(searchTerm, branchId, tipeOrder
                                                                                            , _pageIndex, _pageSize, _totalPage, _recCount);
                pagination.SearchTerm = searchTerm;
                pagination.PageIndex = (int)_pageIndex.Value;
                pagination.PageSize = (int)_pageSize.Value;
                pagination.TotalPages = _totalPage._value != null ? (int)_totalPage._value : 0;
                pagination.RecordCount = _recCount._value != null ? (int)_recCount._value : 0;
                pagination.Model = data;

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