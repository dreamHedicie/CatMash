using CatMash.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatMash.WebAPI.Services
{
    public class LatelierClient : ILatelierClient
    {
        private readonly HttpClient _client;

        public LatelierClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://latelier.co");
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            httpClient.DefaultRequestHeaders.Add("User-agent", "CatMash");
            _client = httpClient;
        }

        public async Task<IEnumerable<Image>> GetImages()
        {
            var response = await _client.GetAsync("data/cats.json");
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Request error.");
            }
            return (await response.Content.ReadAsAsync<ImageCollection>()).Images;
        }
    }
}
