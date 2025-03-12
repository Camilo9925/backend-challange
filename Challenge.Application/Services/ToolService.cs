using Challenge.Domain.Entities;
using Challenge.Infrastructure.Repositories;
using FluentValidation;

namespace Challenge.Application.Services;

public class ToolService : IToolService
{
    private readonly IToolRepository _repository;
    private readonly IValidator<InputTool> _validator;

    public ToolService(IToolRepository repository, IValidator<InputTool> validator)
    {
        _repository = repository;
        _validator = validator;
    }
    public Task<List<OutputTool>> GetAll()
    {
        throw new NotImplementedException();
    }
    public Task<List<OutputTool>> GetByTag(string tag)
    {
        throw new NotImplementedException();
    }

    public Task<OutputTool> Create(InputTool tool)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(string id)
    {
        throw new NotImplementedException();
    }      
}
