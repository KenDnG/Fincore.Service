using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces.CM;

namespace FINCORE.SERVICE.MINIAPI.Repositories.EF.CM
{
    public class CMRepositoryEF : ICM
    {
        private AcquisitionContext acquisitionContext;

        public CMRepositoryEF(AcquisitionContext acquisitionContext)
        {
            this.acquisitionContext = acquisitionContext;
        }

        public async Task<APIResponse> GetPaginationItem(string? searchTerm,
                                                        string? item_id,
                                                        string? item_brand_id,
                                                        string? asset_kind_class_id,
                                                        int pageIndex,
                                                        double pageSize,
                                                        int? totalPage,
                                                        double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_itemResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_itemResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_itemAsync(searchTerm, item_id, item_brand_id, asset_kind_class_id, _pageIndex, _pageSize, _totalPage, _recCount);
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

        public async Task<APIResponse> GetPaginationDealer(string? searchTerm,
                                                            string? item_id,
                                                            string? is_item_new,
                                                            string? branch_id,
                                                            string? item_merk,
                                                            int pageIndex,
                                                            double pageSize,
                                                            int? totalPage,
                                                            double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_dealerResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_dealerResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_dealerAsync(searchTerm, item_id, is_item_new, branch_id, item_merk, _pageIndex, _pageSize, _totalPage, _recCount);
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

        public async Task<APIResponse> GetPaginationSurveyor(string? searchTerm,
                                                            string? item_id,
                                                            int pageIndex,
                                                            double pageSize,
                                                            int? totalPage,
                                                            double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_surveyorResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_surveyorResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_surveyorAsync(searchTerm, item_id, _pageIndex, _pageSize, _totalPage, _recCount);
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

        public async Task<APIResponse> GetPaginationMarketingHead(string? searchTerm,
                                                                    string? item_id,
                                                                    int pageIndex,
                                                                    double pageSize,
                                                                    int? totalPage,
                                                                    double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_marketingheadResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_marketingheadResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_marketingheadAsync(searchTerm, item_id, _pageIndex, _pageSize, _totalPage, _recCount);
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

        public async Task<APIResponse> GetPaginationCGSNo(string? searchTerm,
                                                            string? BranchId,
                                                            string? CompanyId,
                                                            int pageIndex,
                                                            double pageSize,
                                                            int? totalPage,
                                                            double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_CGSNoResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_CGSNoResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_CGSNoAsync(searchTerm, BranchId, CompanyId, _pageIndex, _pageSize, _totalPage, _recCount);
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

        public async Task<APIResponse> GetPaginationOldNPP(string? searchTerm,
                                                            string? BranchId,
                                                            string? CompanyId,
                                                            string? ItemMerkTypeID,
                                                            int pageIndex,
                                                            double pageSize,
                                                            int? totalPage,
                                                            double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_OldNPPResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_OldNPPResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_OldNPPAsync(searchTerm, BranchId, CompanyId, ItemMerkTypeID, _pageIndex, _pageSize, _totalPage, _recCount);
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

        public async Task<APIResponse> GetPaginationPerantara(string? searchTerm,
                                                            string? BranchId,
                                                            string? CompanyId,
                                                            string? TipePerantara,
                                                            int pageIndex,
                                                            double pageSize,
                                                            int? totalPage,
                                                            double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_perantaraResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_perantaraResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_perantaraAsync(searchTerm, BranchId, CompanyId, TipePerantara, _pageIndex, _pageSize, _totalPage, _recCount);
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

        public async Task<APIResponse> GetPaginationBankName(string? searchTerm,
                                                            string? BranchId,
                                                            string? CompanyId,
                                                            string? PemilikRekening,
                                                            int pageIndex,
                                                            double pageSize,
                                                            int? totalPage,
                                                            double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_lookup_banknameResult>();
                var pagination = new Pagination<sp_get_pagination_lookup_banknameResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_lookup_banknameAsync(searchTerm, BranchId, CompanyId, PemilikRekening, _pageIndex, _pageSize, _totalPage, _recCount);
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