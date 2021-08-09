using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FavoriteMovies.OmdbApi
{
    public class OmdbApiHttpClient : HttpClient
    {
        public OmdbApiHttpClient()
        {
            this.BaseAddress = new Uri(@"https://www.omdbapi.com/");
        }


        public async Task<T> GetAsync<T>(string uri, string key = null)
        {
            HttpResponseMessage responseMessage = await GetAsync(uri);

            
            string jsonResponse = await responseMessage.Content.ReadAsStringAsync();

            string jsonStr = string.Empty;


            if (key != null)
            {
                var jObject = JObject.Parse(jsonResponse);

                jsonStr = jObject[key].ToString();
            }
            else
            {
                jsonStr = jsonResponse;
            }


            return JsonConvert.DeserializeObject<T>(jsonStr);
        }
    }
}