using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Dispatcher
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand
        {
            if (command == null) throw new ArgumentNullException(nameof(command));

            var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;
            if (handler == null) throw new ArgumentException($"Handler not found for command type: {command.GetType().Name}");

            handler.Handle(command);
        }
    }
}
