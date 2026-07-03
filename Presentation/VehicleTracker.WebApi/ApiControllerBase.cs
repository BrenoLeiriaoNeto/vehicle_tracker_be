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
    private IMediator? _mediator;

    protected IMediator Mediator =>
        _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected string CurrentUserId
    {
        get
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                         ?? User.FindFirst("sub")?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                throw new InvalidOperationException("O ID do usuário não foi encontrado no token.");
            }

            return userId;
        }
    }
}