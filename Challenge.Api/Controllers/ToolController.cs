using Challenge.Application.Services;
using Challenge.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Controllers;

[Route("[controller]")]
public class ToolController : Controller
{
    private readonly ToolService _service;

    public ToolController(ToolService service)
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
    [HttpGet]
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
    [HttpDelete]
    public async Task<ActionResult<bool>> Delete([FromRoute] string id)
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
