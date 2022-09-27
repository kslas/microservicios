using Lil.Customers.Controllers;
using Lil.Customers.DAL;
using Microsoft.AspNetCore.Mvc;
using Lil.Customers.Models;
using Newtonsoft.Json;
using System.Reflection.Metadata;

namespace Lil.CustomerTest
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void GetAsyncReturnsOk()
        {

            var customersProvider = new CustomersProvider();
            var customerController = new CustomersController(customersProvider);


            var result = customerController.GetAsync("1").Result;

          
        

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));


        }


        [TestMethod]
        public async Task GetSameCustomer()
        {

            var customersProvider = new CustomersProvider();
            var customerController = new CustomersController(customersProvider);


            var actionResult = await customerController.GetAsync("1");

           
            OkObjectResult okResult = actionResult as OkObjectResult;

            var value = okResult.Value;

           
            Customer C1 = new Customer();
            C1.Id = "1";
            C1.Name = "Rodrigo";
            C1.City = "Ciudad de México";


        

           
            var obj1 = JsonConvert.SerializeObject(C1);
            var obj2 = JsonConvert.SerializeObject(value);

           
           
         

            Assert.IsNotNull(value);
            Assert.AreEqual(obj1, obj2);



        }

    }
}