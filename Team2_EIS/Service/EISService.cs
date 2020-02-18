using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace Team2_EIS.Service
{
    public class EISService
    {
        HttpClient client = new HttpClient();
        public EISService()
        {
            string api = $"{WebConfigurationManager.AppSettings["Team2API"]}api/EIS/";
            client.BaseAddress = new Uri(api);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync<T>(string path, T type)
        {
            T obj = default(T);
            try
            {
                using (HttpResponseMessage res = await client.GetAsync(path))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        obj = JsonConvert.DeserializeObject<T>(await res.Content.ReadAsStringAsync());
                    }
                    return obj;
                }
            }
            catch
            {
                return obj;
            }
        }
    }
}