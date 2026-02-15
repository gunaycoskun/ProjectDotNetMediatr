using Mediator.Net.Context;
using Mediator.Net.Contracts;
using ProjectDotNetMediatr.DTOs;

namespace ProjectDotNetMediatr.CQRS.Queries;

public class GetUserQuery : IRequest
{
    public Guid UserId { get; set; }
}

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
{
    public async Task<UserDto> Handle(IReceiveContext<GetUserQuery> context, CancellationToken cancellationToken)
    {
        // Handle the query and return response
        return new UserDto { Id = context.Message.UserId, Name = "John Doe" };
    }
}
