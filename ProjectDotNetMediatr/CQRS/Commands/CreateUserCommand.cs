using Mediator.Net.Context;
using Mediator.Net.Contracts;
using ProjectDotNetMediatr.CQRS.Events;

namespace ProjectDotNetMediatr.CQRS.Commands;

// Command (no response)
public class CreateUserCommand : ICommand
{
    public string Name { get; set; }
    public string Email { get; set; }
}

public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
{
    public async Task Handle(IReceiveContext<CreateUserCommand> context, CancellationToken cancellationToken)
    {
        // Handle the command
        // var user = new User(context.Message.Name, context.Message.Email);
        // Save user...
        
        // Publish an event
        await context.PublishAsync(new UserCreatedEvent { UserId = Guid.NewGuid() });
    }
}