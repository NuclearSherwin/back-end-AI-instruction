using backend_lab.Context;
using backend_lab.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        
        private readonly MongoDbContext _dbContext;

        public OrdersController(MongoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // POST: api/Orders
        [HttpPost]
        public IActionResult PostOrder(Order order)
        {
            
            // Obtain UserId from the cookie
            var userId = HttpContext.Request.Cookies["UserId"];

            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest("UserId not found in cookie.");
            }

            // Set the UserId in the order
            order.UserId = userId;

            _dbContext.Orders.InsertOne(order);
            return Ok(order); // Return the newly created order without a CreatedAtAction
        }


        

    }
}