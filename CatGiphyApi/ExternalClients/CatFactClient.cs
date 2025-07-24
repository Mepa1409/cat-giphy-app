using CatGiphyApi.Models;

namespace CatGiphyApi.ExternalClients
{
    public class CatFactClient
    {
        private readonly HttpClient _httpClient;

        public CatFactClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // Consumimos un fact aleatorio desde la API externa
        public async Task<CatFactResponse?> GetRandomFactAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CatFactResponse>("https://catfact.ninja/fact");
            return response;
        }
    }
}
