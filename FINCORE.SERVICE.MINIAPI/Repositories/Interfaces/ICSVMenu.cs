using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.SERVICE.MINIAPI.Models;

namespace FINCORE.SERVICE.MINIAPI.Repositories.Interfaces
{
    public interface ICSVMenu
    {
        Task<APIResponse> GetCashierSessionVerifyAsync(CashierSessionVerifyModel param);
    }
}
