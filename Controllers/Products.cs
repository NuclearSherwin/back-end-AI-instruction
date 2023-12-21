using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend_lab.Context;
using backend_lab.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace backend_lab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMongoCollection<Product> _products;

        public ProductsController(MongoDbContext dbContext)
        {
            _products = dbContext.Products;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<OkObjectResult> GetProducts()
        {
            var products = await _products.Find(_ => true).ToListAsync();
            return Ok(products);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _products.Find(p => p.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            // Validate the product data here (e.g., check for required fields, valid price, etc.)
            if (string.IsNullOrEmpty(product.Name))
            {
                return BadRequest("Product name is required.");
            }

            if (product.Price <= 0)
            {
                return BadRequest("Product price must be greater than zero.");
            }

            // Insert the product into the database
            try
            {
                _products.InsertOne(product); // MongoDB will generate the _id
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during insertion
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }




        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(string id, Product product)
        {
            // Perform validation and update the product
            // Example: _products.ReplaceOne(p => p.Id == id, product);

            return NoContent();
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            // Perform validation and delete the product
            // Example: _products.DeleteOne(p => p.Id == id);

            return NoContent();
        }
    }
}