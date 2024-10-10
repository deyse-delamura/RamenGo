using Newtonsoft.Json;
using RamenGoApi.Infrastructure.DTOs;

namespace RamenGoApi.Infrastructure.ExternalServices
{
    public class OrderIdGeneratorService
    {
        private readonly HttpClient _httpClient;

        public OrderIdGeneratorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateOrderIdAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.tech.redventures.com.br/orders/generate-id");
            request.Headers.Add("x-api-key", "ZtVdh8XQ2U8pWI2gmZ7f796Vh8GllXoN7mr0djNf");

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Failed to generate order ID");
            }

            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<OrderIdResponse>(content);
            return result.OrderId;
        }
    }
}
