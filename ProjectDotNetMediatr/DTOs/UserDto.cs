using Mediator.Net.Contracts;

namespace ProjectDotNetMediatr.DTOs;

public class UserDto : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}