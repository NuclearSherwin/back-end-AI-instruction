using backend_lab.Models;
using MongoDB.Driver;

namespace backend_lab.Context
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IMongoDatabase database)
        {
            _database = database;
        }

        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>("Products");
            }
        }

        public IMongoCollection<Order> Orders
        {
            get
            {
                return _database.GetCollection<Order>("Orders");
            }
        }

        // You can add more collections here if needed

        // Additional methods or configurations can be added here as well
    }
}