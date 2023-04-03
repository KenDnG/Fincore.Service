using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsIdentityType
    {
        /// <summary>
        /// Get all data active Ms Identity Type
        /// </summary>
        /// <returns></returns>
        Task<APIResponse> GetIdentityTypeAsync();

        /// <summary>
        /// Get data active Ms Identity Type by Customer Type (P/C)
        /// </summary>
        /// <param name="customerType">(P/C) Perorangan or Corporate/Badan Usaha</param>
        /// <returns></returns>
        Task<APIResponse> GetIdentityTypeAsync(string customerType);
    }
}