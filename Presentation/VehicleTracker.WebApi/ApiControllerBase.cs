using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VehicleTracker.WebApi;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public abstract class ApiControllerBase : ControllerBase
{
    protected IMediator Mediator =>
        field ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected string CurrentUserId
    {
        get
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                         ?? User.FindFirst("sub")?.Value;

            return string.IsNullOrEmpty(userId) 
                ? throw new InvalidOperationException("O ID do usuário não foi encontrado no token.")
                : userId;
        }
    }

    protected string CurrentUserName
    {
        get
        {
            var userName = User.FindFirst(ClaimTypes.Name)?.Value;
            
            return string.IsNullOrEmpty(userName)
                ? throw new InvalidOperationException(" O nome do usuário não foi encontrado no token.")
                : userName;
        }
    }
}