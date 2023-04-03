using FINCORE.HELPER.LIBRARY.Response;

namespace FINCORE.SERVICE.MASTERS.Repositories.Interfaces
{
    public interface IMsSource
    {
        /// <summary>
        /// Get Data Narasumber
        /// </summary>
        /// <returns></returns>
        Task<APIResponse> GetSourceAsync();
    }
}