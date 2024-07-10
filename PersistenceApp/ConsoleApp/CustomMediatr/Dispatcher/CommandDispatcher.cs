using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Dispatcher;

internal class CommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    //public void Dispatch<T>(T command) where T : ICommand
    //{
    //    if (command == null) throw new ArgumentNullException(nameof(command));

    //    var handler = _serviceProvider.GetService(typeof(ICommandHandler<T>)) as ICommandHandler<T>;
    //    if (handler == null) throw new ArgumentException($"Handler not found for command type: {command.GetType().Name}");

    //    handler.Handle(command);
    //}

    public async Task DispatchAsync<T>(T command) where T : ICommand
    {
        if (command == null) throw new ArgumentNullException(nameof(command));

        var handler = _serviceProvider.GetService(typeof(ICommandHandler<T>)) as ICommandHandler<T>;
        if (handler == null) throw new ArgumentException($"Handler not found for command type: {command.GetType().Name}");

        await handler.HandleAsync(command);
    }
}