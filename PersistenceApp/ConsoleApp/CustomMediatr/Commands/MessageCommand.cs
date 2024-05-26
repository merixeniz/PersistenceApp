using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Commands
{
    internal record MessageCommand(int Id, string Message) : ICommand
    {
    }
}
