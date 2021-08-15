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


        public async Task<T> GetAsync<T>(string uri, string key = null) where T:class
        {
            HttpResponseMessage responseMessage = await GetAsync(uri);

            var jObject = JObject.Parse(await responseMessage.Content.ReadAsStringAsync());

            if (jObject["Response"]?.ToString() == "False")
                return null;

            return JsonConvert.DeserializeObject<T>(key != null ? jObject[key].ToString() : jObject.ToString());
        }
    }
}