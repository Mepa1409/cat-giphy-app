using System.Net.Http;
using System.Net.Http.Json;
using System.Web;
using CatGiphyApi.Models;

namespace CatGiphyApi.ExternalClients
{
    public class GiphyClient
    {
        private readonly HttpClient _httpClient;
        //Clave de la api(mostrada en el documento de la prueba) 
        private const string ApiKey = "voaNIOg1u7ONPbckzWK71C48YqCOkhVP";

        public GiphyClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.giphy.com/v1/gifs/");
        }

        public async Task<string?> GetGifUrlAsync(string query)
        {
            var queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["api_key"] = ApiKey;
            queryParams["q"] = query;
            queryParams["limit"] = "1";

          
            var offset = new Random().Next(0, 25); 
            queryParams["offset"] = offset.ToString();

            var url = $"search?{queryParams}";

            var response = await _httpClient.GetFromJsonAsync<GiphyResponse>(url);

            return response?.Data.FirstOrDefault()?.Images?.Original?.Url;
        }
    }
}
