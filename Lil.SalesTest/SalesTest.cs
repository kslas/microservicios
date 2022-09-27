using Lil.Sales.Controllers;
using Microsoft.AspNetCore.Mvc;
using Lil.Sales.Models;
using Newtonsoft.Json;
using Lil.Sales.DAL;


namespace Lil.SalesTest
{
    [TestClass]
    public class SalesTest
    {
        [TestMethod]
        public async Task GetSameOrderTotal()
        {


            var salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);



            var result = await salesController.GetAsync("3");
            OkObjectResult okResult = result as OkObjectResult;
            var value = okResult.Value;


            Order order = new Order();
            order.Id = "0004";
            order.CustomerId = "3"; //74 esta el 3
            order.OrderDate = DateTime.Now.AddDays(-10);
            order.Total = 50;
            order.Items = new List<OrderItem>();

            OrderItem it1=new OrderItem();
            it1.OrderId = "0004";
            it1.Id = 1;
            it1.Price = 50;
            it1.ProductId = "5";
            it1.Quantity = 1;
            order.Items.Add(it1);
            
            var bj2 = JsonConvert.SerializeObject(value);
            var OrderItemId= bj2[124].ToString();

            int OrderItemI1 = Int32.Parse(OrderItemId);

            Assert.IsNotNull(value);
            Assert.AreEqual(order.Items.First().Id, OrderItemI1);



        }


        [TestMethod]
        public async Task GetNotNullOrder()
        {


            var salesProvider = new SalesProvider();
            var salesController = new SalesController(salesProvider);



            var result = await salesController.GetAsync("3");
            OkObjectResult okResult = result as OkObjectResult;
            var value = okResult.Value;


            Order order = new Order();
            order.Id = "0004";
            order.CustomerId = "3"; 
            order.OrderDate = DateTime.Now.AddDays(-10);
            order.Total = 50;
            order.Items = new List<OrderItem>();

            OrderItem it1 = new OrderItem();
            it1.OrderId = "0004";
            it1.Id = 1;
            it1.Price = 50;
            it1.ProductId = "5";
            it1.Quantity = 1;
            order.Items.Add(it1);

            var bj2 = JsonConvert.SerializeObject(value);
          

            Assert.IsNotNull(value);
            Assert.IsTrue(order.Items.Count() >= 1);



        }



    }
}