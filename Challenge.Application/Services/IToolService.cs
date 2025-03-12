using Challenge.Domain.Entities;

namespace Challenge.Application.Services;

public interface IToolService
{
    Task<List<OutputTool>> GetAll();
    Task<List<OutputTool>> GetByTag(string tag);
    Task<OutputTool> Create(InputTool tool);
    Task<bool> Delete(string id);
}
