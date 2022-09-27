
using Lil.Products.DAL;
using Lil.Products.Controllers;
using Microsoft.AspNetCore.Mvc;
using Lil.Products.Models;
using Newtonsoft.Json;


namespace Lil.ProductsTets
{
    [TestClass]
    public class ProductsTest
    {
        [TestMethod]
        public async Task GetSameProductID()
        {

            var productsProvider = new ProductsProvider();
            var productsController = new ProductsController(productsProvider);


            
            var actionResult = await productsController.GetAsync("1");

            
            OkObjectResult okResult = actionResult as OkObjectResult;

            var value= okResult.Value;

            
           
            Product p1 = new Product();
            p1.Id ="1";
            p1.Name ="Producto 1";
            p1.Price =0.0;


               


           
            var obj2 = JsonConvert.SerializeObject(value);


            var j = obj2[7].ToString();




            Assert.IsNotNull(value);
            Assert.AreEqual(p1.Id, j);






        }

        [TestMethod]
        public async Task GetSameStatusCode()
        {

            var productsProvider = new ProductsProvider();
            var productsController = new ProductsController(productsProvider);


    
            IActionResult actionResult = await productsController.GetAsync("1");

            
            OkObjectResult okResult = actionResult as OkObjectResult;

            

            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);


            
            



        }
    }
}