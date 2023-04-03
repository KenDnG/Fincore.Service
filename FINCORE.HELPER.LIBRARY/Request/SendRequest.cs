using FINCORE.HELPER.LIBRARY.Response;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINCORE.HELPER.LIBRARY.Request
{
    public class SendRequest
    {
        public async Task< RapindoResponse> GetAPIResponse(string url, Method method, object reqBody, string token_code,string x_tag_user,string nama_cabang,string kode_cabang)
        {
            RapindoResponse result = new RapindoResponse();
            try
            {
                var client = new RestClient();
                var request = new RestRequest(url, method);

                request.AddParameter(BaseRequest.Headers.CONTENT_TYPE, JsonConvert.SerializeObject(reqBody), ParameterType.RequestBody);
                request.AddHeader("token_code", token_code);
                request.AddHeader("x_tag_user", x_tag_user);
                request.AddHeader("nama_cabang",nama_cabang);
                request.AddHeader("kode_cabang",kode_cabang);

                var response = await client.ExecuteAsync(request);

                result = JsonConvert.DeserializeObject<RapindoResponse>(response.Content.ToString());
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}
