using Newtonsoft.Json;

namespace FINCORE.HELPER.LIBRARY.Helper
{
    public class Commons
    {
        public static DateTime GetDefaultDatetime()
        {
            return Convert.ToDateTime("1/1/1900");
        }

        public struct CustomerTypes
        {
            public static readonly string CORPORATE_TYPE_CODE = "C";
            public static readonly string INDIVIDUAL_TYPE_CODE = "P";
        }

        /// <summary>
        /// Convert Json Data Response into your List data object models
        /// </summary>
        /// <typeparam name="T">Your Model</typeparam>
        /// <param name="content">Response JSON Data</param>
        /// <returns></returns>
        public IList<TModel> JsonToList<TModel>(object content)
        {
            var dataResult = new List<TModel>();
            try
            {
                dataResult = JsonConvert.DeserializeObject<List<TModel>>(JsonConvert.SerializeObject(content));
            }
            catch (Exception ex)
            {
                var err = ex.Message;
            }
            return dataResult.ToList();
        }
    }
}