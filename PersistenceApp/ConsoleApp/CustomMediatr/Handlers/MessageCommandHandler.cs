using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Handlers
{
    internal class MessageCommandHandler : ICommandHandler<MessageCommand>
    {
        public void Handle<T>(T command) where T : ICommand
        {
            if (command == null) 
                throw new ArgumentNullException(nameof(command));

            if (command is not MessageCommand messageCommand)
                throw new ArgumentException($"Invalid command type: {command.GetType().Name}");

            Console.WriteLine($"MessageCommandHandler: Id={messageCommand.Id}, Message={messageCommand.Message}");
        }
    }
}
