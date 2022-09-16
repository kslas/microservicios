using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Lil.Search.Interfaces;

namespace Lil.Search.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICostumersService customersService;
        private readonly IProductsService productsService;
        private readonly ISalesService salesService; 
        public SearchController(ICostumersService customersService, IProductsService productsService, ISalesService salesService)
        { 
            this.customersService = customersService;
            this.productsService = productsService;
            this.salesService = salesService;
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> SearchAsync(string customerId)
        {
            if (string.IsNullOrWhiteSpace(customerId))
            {
                return BadRequest();
            }
            
            try
            {
                var customer = await customersService.GetAsync(customerId);
                var sales = await salesService.GetAsync(customerId);

                foreach (var sale in sales)
                    foreach (var item in sale.Items)
                    {
                        var product = await productsService.GetAsync(item.ProductId);

                        item.Product = product;
                    }

                // usamos tipos dinámicos
                var result = new
                {
                    Customer = customer,
                    Sales = sales
                };

                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
