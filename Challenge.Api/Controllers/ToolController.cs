using Challenge.Application.Services;
using Challenge.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Controllers;

[Authorize]
[Route("[controller]")]
public class ToolController : Controller
{
    private readonly IToolService _service;

    public ToolController(IToolService service)
    {
        _service = service;
    }
    [ProducesResponseType<List<OutputTool>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<ActionResult<List<OutputTool>>> GetAll()
    {
        try
        {
            return await _service.GetAll();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [ProducesResponseType<List<OutputTool>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet("tag")]
    public async Task<ActionResult<List<OutputTool>>> GetByTag([FromQuery] string tag)
    {
        try
        {
            return await _service.GetByTag(tag);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [ProducesResponseType<OutputTool>(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpPost]
    public async Task<ActionResult<OutputTool>> Create([FromBody]InputTool input)
    {
        try
        {
            return await _service.Create(input);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [ProducesResponseType<bool>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> Delete(string id)
    {
        try
        {
            return await _service.Delete(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
