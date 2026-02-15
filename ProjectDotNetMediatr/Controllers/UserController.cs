using Mediator.Net;
using Microsoft.AspNetCore.Mvc;
using ProjectDotNetMediatr.CQRS.Commands;
using ProjectDotNetMediatr.CQRS.Events;
using ProjectDotNetMediatr.CQRS.Queries;
using ProjectDotNetMediatr.DTOs;

namespace ProjectDotNetMediatr.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetUser()
    {
        var user = await mediator.RequestAsync<GetUserQuery, UserDto>(
            new GetUserQuery { UserId = Guid.NewGuid() });
        return Ok(user);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateUser()
    {
        await mediator.SendAsync(new CreateUserCommand 
        { 
            Name = "John Doe", 
            Email = "john@example.com" 
        });
        return Ok();
    }
    
    [HttpPost("publish")]
    public async Task<IActionResult> PublishEvent()
    {        
        await mediator.PublishAsync(new UserCreatedEvent { UserId = Guid.NewGuid() });
        return Ok();
    }

    
}