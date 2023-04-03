using FINCORE.HELPER.LIBRARY.Response;
using FINCORE.SERVICE.CSSESSION.DTO;

namespace FINCORE.SERVICE.CSSESSION.Repositories.Interfaces
{
    public interface ICashierSessionVerify
    {
        Task<APIResponse> VerifySession(VerifySessionDTO param);
    }
}
