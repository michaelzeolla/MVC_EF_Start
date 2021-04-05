using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_EF_Start.DataAccess;
using MVC_EF_Start.Models;

namespace MVC_EF_Start.Controllers
{
    public class DatabaseExampleController : Controller
    {
        public ApplicationDbContext dbContext;

        public DatabaseExampleController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ViewResult> DatabaseOperations()
        {
            Order Order1 = new Order();
            //Order1.id = 1234;
            Order1.totalItems = 2;
            Order1.totalPrice = 11;
            Order1.date = "04/04/2021";

            Order Order2 = new Order();
            Order2.totalItems = 2;
            Order2.totalPrice = 9;
            Order2.date = "04/03/2021";

            Product Product1 = new Product();
            //Product1.id = 4312;
            Product1.name = "Doritos";
            Product1.brand = "Frito Lay";
            Product1.price = 5;

            Product Product2 = new Product();
            //Product2.id = 4321;
            Product2.name = "Oreos";
            Product2.brand = "Nabisco";
            Product2.price = 6;

            Product Product3 = new Product();
            Product3.name = "Life Savers";
            Product3.brand = "Mars";
            Product3.price = 3;

            OrderItem orderItem1 = new OrderItem
            {
                PurchasedItem = Product1,
                PlacedOrder = Order1

            };

            OrderItem orderItem2 = new OrderItem
            {
                PurchasedItem = Product2,
                PlacedOrder = Order1
            };

            OrderItem orderItem3 = new OrderItem
            {
                PurchasedItem = Product2,
                PlacedOrder = Order2
            };

            OrderItem orderItem4 = new OrderItem
            {
                PurchasedItem = Product3,
                PlacedOrder = Order2
            };
          

            dbContext.Orders.Add(Order1);
            dbContext.Orders.Add(Order2);
            dbContext.Products.Add(Product1);
            dbContext.Products.Add(Product2);
            dbContext.Products.Add(Product3);
            dbContext.OrderItems.Add(orderItem1);
            dbContext.OrderItems.Add(orderItem2);
            dbContext.OrderItems.Add(orderItem3);
            dbContext.OrderItems.Add(orderItem4);


            dbContext.SaveChanges();

            return View();
        }

        public ViewResult LINQOperations()
        {
            Product ProductRead1 = dbContext.Products
                                            .Include(o => o.ProductOrders)
                                            .Where(o => o.name == "Oreos")
                                            .First();
            //Product ProductRead2 = dbContext.Products
            //                                .Include(p => p.ProductOrders.Select(c => c.PlacedOrder.totalPrice))
            //                                .Where(p => p.name == "Oreos")
            //                                .First();
            //Order OrderRead1 = dbContext.Products
            //                            .Include(p => p.ProductOrders)
            //                            .Where(p => p.name == "Oreos")
            //                            .
            //Order OrderRead2 = dbContext.Orders
            //                            .Include(o => o.ItemsInOrder.Select(c => c.PurchasedItem))
            //                            )
            //                            .OrderByDescending(o => o.totalPrice)
            //                            .FirstOrDefault();


            return View();
        }

    }
}