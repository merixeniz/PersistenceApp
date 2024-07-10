using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Commands
{
    public record UndoCommand(Guid EventId) : ICommand;
}
