using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;

namespace FINCORE.SERVICE.MINIAPI.Repositories.EF.Acquisition
{
    public class AcquisitionRepository : IAcquisition
    {
        private AcquisitionContext acquisitionContext;

        public AcquisitionRepository(AcquisitionContext acquisitionContext)
            => this.acquisitionContext = acquisitionContext;

        public async Task<APIResponse> GetPaginationAcquisitionMobil(string branch_id, string? searchTerm, int pageIndex, double pageSize, int? totalPage, double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_acquisition_mobilResult>();
                var pagination = new Pagination<sp_get_pagination_acquisition_mobilResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_acquisition_mobilAsync(branch_id, searchTerm
                                                                                                        , _pageIndex, _pageSize
                                                                                                        , _totalPage, _recCount);
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

        public async Task<APIResponse> GetPaginationAcquisitionMotor(string branch_id, string? searchTerm, string? searchTerm1, int pageIndex, double pageSize, int? totalPage, double? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_acquisition_motorResult>();
                var pagination = new Pagination<sp_get_pagination_acquisition_motorResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_get_pagination_acquisition_motorAsync(branch_id, searchTerm, searchTerm1
                                                                                                        , _pageIndex, _pageSize
                                                                                                        , _totalPage, _recCount);
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

        public async Task<APIResponse> GetPaginationNikKonsumen(string? employeeName, string? branchId, bool isKonsol, bool includePos, int pageIndex, double pageSize, int? totalPage, double? recCount)
        {
            try
            {
                var data = new List<sp_pagination_get_nik_konsumenResult>();
                var pagination = new Pagination<sp_pagination_get_nik_konsumenResult>();

                var _pageIndex = new OutputParameter<int?> { _value = pageIndex };
                var _pageSize = new OutputParameter<double?> { _value = pageSize };
                var _totalPage = new OutputParameter<int?> { _value = totalPage };
                var _recCount = new OutputParameter<double?> { _value = recCount };

                data = await acquisitionContext.GetProcedures().sp_pagination_get_nik_konsumenAsync(employeeName, branchId, isKonsol, includePos
                                                                                                        , _pageIndex, _pageSize
                                                                                                        , _totalPage, _recCount);
                pagination.SearchTerm = employeeName;
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