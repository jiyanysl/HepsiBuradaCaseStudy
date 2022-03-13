using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace HepsiBuradaTech.Models
{
    public class MongoDBContext
    {
        private readonly IConfiguration _configuration;
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDBContext(IConfiguration configuration)
        {
            _configuration = configuration;

            var connectionString = _configuration.GetValue<string>("MongoDBConfiguration:ConnectionString");
            var db = _configuration.GetValue<string>("MongoDBConfiguration:Database");

            var client = new MongoClient(connectionString);
            _mongoDatabase = client.GetDatabase(db);
        }
        public IMongoCollection<Products> Products => _mongoDatabase.GetCollection<Products>(nameof(Products));
        public IMongoCollection<Orders> Orders => _mongoDatabase.GetCollection<Orders>(nameof(Orders));
        public IMongoCollection<Campaigns> Campaigns => _mongoDatabase.GetCollection<Campaigns>(nameof(Campaigns));


    }
}
