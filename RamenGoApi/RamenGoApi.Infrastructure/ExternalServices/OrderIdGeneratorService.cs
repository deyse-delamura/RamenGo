using Newtonsoft.Json;
using RamenGoApi.Application.Interfaces;
using RamenGoApi.Infrastructure.DTOs;

namespace RamenGoApi.Infrastructure.ExternalServices
{
    public class OrderIdGeneratorService : IOrderIdGeneratorExternalService
    {
        private readonly HttpClient _httpClient;

        public OrderIdGeneratorService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GenerateOrderIdAsync()
        {
            var response = await _httpClient.PostAsync("/orders/generate-id", null);

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
