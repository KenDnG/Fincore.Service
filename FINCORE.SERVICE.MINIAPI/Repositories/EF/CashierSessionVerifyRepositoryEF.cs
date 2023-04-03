using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentModel;
using FINCORE.SERVICE.MINIAPI.Models;
using FINCORE.SERVICE.MINIAPI.Repositories.Interfaces;

namespace FINCORE.SERVICE.MINIAPI.Repositories.EF
{
    public class CashierSessionVerifyRepositoryEF : ICSVMenu
    {
        private readonly PAYMENTContext _paymentContext;

        public CashierSessionVerifyRepositoryEF(PAYMENTContext paymentContext)
        {
            _paymentContext = paymentContext;
        }
        public async Task<APIResponse> GetCashierSessionVerifyAsync(CashierSessionVerifyModel param)
        {
            try
            {
                var pagination = new Pagination<sp_get_pagination_cashier_session_verifyResult>();
                var _pageIndex = new OutputParameter<int?> { _value = param.PageIndex };
                var _pageSize = new OutputParameter<int?> { _value = param.PageSize };
                var _totalPage = new OutputParameter<int?>();
                var _recCount = new OutputParameter<double?>();

                List<sp_get_pagination_cashier_session_verifyResult> data = await _paymentContext
                    .GetProcedures()
                    .sp_get_pagination_cashier_session_verifyAsync(
                        param.BranchId, param.SearchTerm, _pageIndex, _pageSize, _totalPage, _recCount);

                pagination.SearchTerm = param.SearchTerm;
                pagination.PageIndex = param.PageIndex;
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
                return new APIResponse(
                    Collection.Codes.INTERNAL_SERVER_ERROR,
                    Collection.Status.FAILED,
                    ex.Message,
                    new { });
            }
        }
    }
}
