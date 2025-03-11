using Challenge.Domain.Entities;
using Challenge.Infrastructure.Context;
using MongoDB.Driver;

namespace Challenge.Infrastructure.Repositories;

public class ToolRepository : IToolRepository
{
    private readonly MongoDb _context;
    public async Task<List<OutputTool>> GetAll()
    {
        return await _context.OutputTaskCollection.Find(_ => true).ToListAsync();
    }
    public async Task<List<OutputTool>> GetByTag(string tag)
    {
        var filter = Builders<OutputTool>.Filter.AnyEq(t => t.Tags, tag);
        return await _context.OutputTaskCollection.Find(filter).ToListAsync();
    }

    public async Task<OutputTool> Create(InputTool tool)
    {
        var output = new OutputTool()
        {
            Id = tool.Id,
            Title = tool.Title,
            Description = tool.Description,
            Link = tool.Link,
            Tags = tool.Tags
        };
        await _context.OutputTaskCollection.InsertOneAsync(output);
        return output;
    }

    public async Task<bool> Delete(string id)
    {
        var filter = Builders<OutputTool>.Filter.Eq(t => t.Id, id);
        var result = await _context.OutputTaskCollection.DeleteOneAsync(filter);
        return result.DeletedCount > 0;
    }
}
