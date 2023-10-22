using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ZipCodesFromWebService
{
    public class WebRequest
    {

        HttpClient _client;

        public WebRequest()
        {
            _client = new HttpClient();
        }

        public async Task<Response> GetData(string query)
        {
            Response res = null;
            try
            {
                var response = await _client.GetAsync(query);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<Response>(content);
                    JObject d = JObject.Parse(content);
                    Debug.WriteLine(d.Property("country abbreviation"));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\t\tERROR {0}", ex.Message);
            }

            return res;
        }
    }
}