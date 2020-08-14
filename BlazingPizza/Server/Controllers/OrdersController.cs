using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazingPizza.Server.Models;
using BlazingPizza.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlazingPizza.Server.Controllers
{
    [Route("orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly PizzaStoreContext Context;
        public OrdersController(PizzaStoreContext context)
        {
            this.Context = context;
        }

        [HttpPost]
        public async Task<ActionResult<int>> PlaceOrder(Order order)
        {
            order.CreatedTime = DateTime.Now;
            order.DeliveryLocation = new LatLong(19.043679206924864, -98.19811254438645);

            foreach (var pizza in order.Pizzas)
            {
                pizza.SpecialId = pizza.Special.Id;
                pizza.Special = null;

                foreach (var topping in pizza.Toppings)
                {
                    topping.ToppingId = topping.Topping.Id;
                    topping.Topping = null;
                }
            }

            Context.Orders.Attach(order);
            await Context.SaveChangesAsync();

            return order.OrderId;
        }
    }
}
