using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Acquisition.AcquisitionModel;
using FINCORE.LIBRARY.DTO.EntityFramework.Masters.MastersContext;
using FINCORE.LIBRARY.DTO.EntityFramwork.Masters.MastersModels;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;

namespace FINCORE.SERVICE.MINIAPI.Repositories.Acquisition
{
    public class NPPMenuRepository : INPPMenu
    {
        private readonly AcquisitionContext acquisitionContext;
        private readonly MastersContext mastersContext;

        public NPPMenuRepository(AcquisitionContext acquisitionContext
                                , MastersContext _mastersContext)
        {
            this.acquisitionContext = acquisitionContext;
            this.mastersContext = _mastersContext;
        }

        public async Task<APIResponse> GetPaginationNPPs(string? searchTerm
                                                        , int pageIndex
                                                        , int pageSize
                                                        , int? totalPage
                                                        , int? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_NPPResult>();
                var pagination = new Pagination<sp_get_pagination_NPPResult>();

                var _pageIndex = new LIBRARY.DTO.EntityFramework
                                    .Acquisition.AcquisitionContext
                                    .OutputParameter<int?>
                { _value = pageIndex };
                var _pageSize = new LIBRARY.DTO.EntityFramework
                                    .Acquisition.AcquisitionContext
                                    .OutputParameter<double?>
                { _value = pageSize };
                var _totalPage = new LIBRARY.DTO.EntityFramework
                                    .Acquisition.AcquisitionContext
                                    .OutputParameter<int?>
                { _value = totalPage };
                var _recCount = new LIBRARY.DTO.EntityFramework
                                    .Acquisition.AcquisitionContext
                                    .OutputParameter<double?>
                { _value = recCount };

                data = await acquisitionContext
                            .GetProcedures()
                            .sp_get_pagination_NPPAsync(searchTerm, _pageIndex
                                                        , _pageSize, _totalPage
                                                        , _recCount);

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

        public async Task<APIResponse> GetPaginationDealerBankAccount(string? searchTerm
                                                                        , int pageIndex
                                                                        , int pageSize
                                                                        , int? totalPage
                                                                        , int? recCount)
        {
            try
            {
                var data = new List<sp_get_pagination_npp_dealer_bank_accountResult>();
                var pagination = new Pagination<sp_get_pagination_npp_dealer_bank_accountResult>();

                var _pageIndex = new LIBRARY.DTO.EntityFramework
                                    .Masters.MastersContext
                                    .OutputParameter<int?>
                { _value = pageIndex };
                var _pageSize = new LIBRARY.DTO.EntityFramework
                                    .Masters.MastersContext
                                    .OutputParameter<double?>
                { _value = pageSize };
                var _totalPage = new LIBRARY.DTO.EntityFramework
                                    .Masters.MastersContext
                                    .OutputParameter<int?>
                { _value = totalPage };
                var _recCount = new LIBRARY.DTO.EntityFramework
                                    .Masters.MastersContext
                                    .OutputParameter<double?>
                { _value = recCount };

                data = await mastersContext
                            .GetProcedures()
                            .sp_get_pagination_npp_dealer_bank_accountAsync(searchTerm, _pageIndex
                                                                            , _pageSize, _totalPage
                                                                            , _recCount);
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