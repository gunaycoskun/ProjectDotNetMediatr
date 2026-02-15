using Mediator.Net.Context;
using Mediator.Net.Contracts;

namespace ProjectDotNetMediatr.CQRS.Events;

public class UserCreatedEvent : IEvent
{
    public Guid UserId { get; set; }
}

public class UserCreatedEventHandler : IEventHandler<UserCreatedEvent>
{
    public async Task Handle(IReceiveContext<UserCreatedEvent> context, CancellationToken cancellationToken)
    {
        Console.WriteLine($"User {context.Message.UserId} was created!");
    }
}