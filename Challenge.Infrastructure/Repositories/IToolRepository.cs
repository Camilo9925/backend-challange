using Challenge.Domain.Entities;

namespace Challenge.Infrastructure.Repositories;

public interface IToolRepository
{
    Task<List<OutputTool>> GetAll();
    Task<List<OutputTool>> GetByTag(string tag);
    Task<OutputTool> Create(InputTool tool);
    Task<bool> Delete(string id);
}
