using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Commands;

public record TransferCommand(Guid FromAccountId, Guid ToAccountId, decimal Amount) : ICommand
{
    public bool Succeeded { get; set; }
}