using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace Challenge.Infrastructure.Context;

public class MongoDb
{
    public IMongoDatabase DB { get; }
    public MongoDb(IConfiguration configuration)
    {
        try
            {                
                var connectionString = configuration.GetConnectionString("MongoDbConnection");                
                var clientSettings = MongoClientSettings.FromConnectionString(connectionString);                
                var client = new MongoClient(clientSettings);               
                DB = client.GetDatabase("challenge-database");
            }
            catch (Exception ex)
            {
                throw new MongoException("Could not connect to MongoDb.", ex);
            }
    }
}
