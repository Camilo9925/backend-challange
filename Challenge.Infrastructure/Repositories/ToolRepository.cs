using Challenge.Domain.Entities;
using Challenge.Infrastructure.Context;
using MongoDB.Driver;

namespace Challenge.Infrastructure.Repositories;

public class ToolRepository : IToolRepository
{
    private readonly MongoDb _context;
    public Task<List<OutputTool>> GetAll()
    {
        throw new NotImplementedException();
    }
    public Task<List<OutputTool>> GetByTag(string tag)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(InputTool tool)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(string id)
    {
        throw new NotImplementedException();
    }  

    
}
