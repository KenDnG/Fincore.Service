using FINCORE.HELPER.LIBRARY.BaseModel;
using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentContext;
using FINCORE.LIBRARY.DTO.EntityFramework.Payment.PaymentModel;
using FINCORE.SERVICE.CSSESSION.DTO;
using FINCORE.SERVICE.CSSESSION.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FINCORE.SERVICE.CSSESSION.Repositories.EF
{
    public sealed class CashierSessionRepository : ICashierSessionRepository
    {
        private readonly PAYMENTContext _paymentContext;

        public CashierSessionRepository(PAYMENTContext paymentContext)
        {
            _paymentContext = paymentContext;
        }

        public async Task<bool> GetOpenedCashierSesionAsync(string branchId)
        {
            try
            {
                return await _paymentContext.TrCashierSession
                            .AnyAsync(cs => cs.SessionId.Contains(branchId) && cs.CloseDate == null); 
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<APIResponse> GetCashierSessionAsync(string SessionId)
        {
            try
            {

                TrCashierSession? cashierSession = await _paymentContext.TrCashierSession
                            .Where(cs => cs.SessionId.Contains (SessionId))
                            .OrderByDescending(cs => cs.CreatedOn)
                            .FirstOrDefaultAsync();

                return new APIResponse(data: cashierSession);

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

        public async Task<APIResponse> GetCashierSessionAsync(QueryParamDTO queryParamDTO)
        {
            try
            {
                var pagination = new Pagination<sp_get_pagination_cashier_sessionResult>();
                var _pageIndex = new OutputParameter<int?> { _value = queryParamDTO.PageIndex };
                var _pageSize = new OutputParameter<int?> { _value = queryParamDTO.PageSize };
                var _totalPage = new OutputParameter<int?>();
                var _recCount = new OutputParameter<double?>();

                List<sp_get_pagination_cashier_sessionResult> data = await _paymentContext
                                    .GetProcedures()
                                    .sp_get_pagination_cashier_sessionAsync(
                                        queryParamDTO.BranchId, queryParamDTO.SearchTerm, _pageIndex, _pageSize, _totalPage, _recCount);

                pagination.SearchTerm = queryParamDTO.SearchTerm;
                pagination.PageIndex = queryParamDTO.PageIndex;
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

        public async Task<APIResponse> InsertCashierSessionAsync(TrCashierSession cashierSession)
        {

            try
            {
    
                var entity = await _paymentContext.TrCashierSession.AddAsync(cashierSession);
                await _paymentContext.SaveChangesAsync();

                return new APIResponse(
                    Collection.Codes.SUCCESS,
                    Collection.Status.SUCCESS,
                    Collection.Messages.SUCCESS,
                    new { });

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

        public async Task<APIResponse> CloseCashierSessionAsync(UpdateCashierSessionDTO updateCashierSessionDTO)
        {
            try
            {
                TrCashierSession? cashierSessionEntity = await _paymentContext.TrCashierSession.FindAsync(updateCashierSessionDTO.SessionId);

                if (cashierSessionEntity is null)
                    return new APIResponse(
                        Collection.Codes.BAD_REQUEST,
                        Collection.Status.FAILED,
                        $"Session Id: {updateCashierSessionDTO.SessionId} not found",
                        new { });

                //check if session has closed
                if (cashierSessionEntity.CloseDate is not null)
                    return new APIResponse(
                        Collection.Codes.FORBIDDEN,
                        Collection.Status.FAILED,
                        $"Session Id: {updateCashierSessionDTO.SessionId} already closed",
                        new { });

                _paymentContext.TrCashierSession.Attach(cashierSessionEntity);

                cashierSessionEntity.CashAmount = (decimal?)updateCashierSessionDTO.CashAmount;
                cashierSessionEntity.CloseAmount = (decimal?)updateCashierSessionDTO.CurrentAmount;
                cashierSessionEntity.CloseBy = updateCashierSessionDTO.UserName;
                cashierSessionEntity.CloseDate = DateTime.Now;

                _paymentContext.Entry(cashierSessionEntity).State = EntityState.Modified;

                await _paymentContext.SaveChangesAsync();

                return new APIResponse(
                    Collection.Codes.SUCCESS,
                    Collection.Status.SUCCESS,
                    "Session closed successfully",
                    new { });

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
