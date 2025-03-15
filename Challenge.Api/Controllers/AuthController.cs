using Challenge.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Challenge.Api.Controllers;

[Route("[controller]")]
public class AuthController : Controller
{
    [HttpPost]
    public async Task<ActionResult<string>> Auth(string username)
    {
        try
        {
            if (username == "lucas")
            {
                var token = await Task.Run(() => TokenService.GenerateToken(username));
                return Ok(token);
            }

            return Unauthorized("Usuário não autorizado.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
