using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using Challenge.Domain.Entities;

namespace Challenge.Infrastructure.Context;

public class MongoDb
{
    private readonly IMongoDatabase _dataBase;
    public MongoDb(string connectionString, string dataBaseName)
    {
        var client = new MongoClient(connectionString);
        _dataBase = client.GetDatabase(dataBaseName);
    }
    public IMongoCollection<OutputTool> OutputTaskCollection =>
        _dataBase.GetCollection<OutputTool>("OutputTools");
}
