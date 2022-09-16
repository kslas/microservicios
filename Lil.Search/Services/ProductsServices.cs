using Lil.Search.Interfaces;
using Lil.Search.Models;
using Microsoft.Extensions.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Lil.Search.Services
{
    public class ProductsServices : IProductsService
    {
        private readonly IHttpClientFactory httpClientFactory;
   
        public ProductsServices(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<Product?> GetAsync(string Id)
        {
            var client = httpClientFactory.CreateClient("productsService");

            var response = await client.GetAsync($"api/products/{Id}");

            //Product? product = null;

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                var product = JsonConvert.DeserializeObject<Product>(content);

                return product;
            }

            return null;
        }
    }
}
