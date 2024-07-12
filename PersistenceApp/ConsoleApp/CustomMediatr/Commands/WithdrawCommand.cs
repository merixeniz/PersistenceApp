using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Commands;

public record WithdrawCommand(Guid AccountId, decimal Amount) : ICommand
{
    public bool Succeeded { get; set; }
}