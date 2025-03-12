using Challenge.Application.Exceptions;
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
    public async Task<List<OutputTool>> GetAll()
    {
        var tools = await _repository.GetAll();
        if (tools == null || tools.Count == 0)
            throw new NotFoundException("No tools found.");

        return tools;
    }
    public async Task<List<OutputTool>> GetByTag(string tag)
    {
        if (string.IsNullOrWhiteSpace(tag))
            throw new Challenge.Application.Exceptions.ValidationException("Tag cannot be empty.");

        var tools = await _repository.GetByTag(tag);
        if (tools == null || tools.Count == 0)
            throw new NotFoundException($"No tools found with the tag '{tag}'.");

        return tools;
    }

    public async Task<OutputTool> Create(InputTool tool)
    {
        var validationResult = await _validator.ValidateAsync(tool);
        if (!validationResult.IsValid)
        {
            var errors = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
            throw new Challenge.Application.Exceptions.ValidationException(errors);
        }

        return await _repository.Create(tool);
    }

    public async Task<bool> Delete(string id)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new Challenge.Application.Exceptions.ValidationException("ID cannot be empty.");

        var deleted = await _repository.Delete(id);
        if (!deleted)
            throw new NotFoundException($"No tool found with ID '{id}'.");

        return true;
    }
}
