using Lil.Search.Interfaces;
using Lil.Search.Models;
using Microsoft.Extensions.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lil.Search.Services
{
    public class CustomersService : ICostumersService
    {
        private readonly IHttpClientFactory httpClientFactory;
        public CustomersService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<Customer?> GetAsync(string Id) 
        {
            var client = httpClientFactory.CreateClient("customersService");

            var response = await client.GetAsync($"api/customers/{Id}");

            //Customer? customer = null;

            if (response.IsSuccessStatusCode) 
            {
                var content = await response.Content.ReadAsStringAsync();

                var customer = JsonConvert.DeserializeObject<Customer>(content);

                return customer;
            }

            return null;
        }
    }
}
