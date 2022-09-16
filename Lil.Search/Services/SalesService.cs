using Lil.Search.Interfaces;
using Lil.Search.Models;
using Microsoft.Extensions.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace Lil.Search.Services
{
    public class SalesService : ISalesService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public SalesService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<ICollection<Order?>> GetAsync(string customerId)
        {
            var client = httpClientFactory.CreateClient("salesService");

            var response = await client.GetAsync($"api/sales/{customerId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var order = JsonConvert.DeserializeObject<ICollection<Order?>>(content);

                return order;
            }

            return null;
        }

    }
}
