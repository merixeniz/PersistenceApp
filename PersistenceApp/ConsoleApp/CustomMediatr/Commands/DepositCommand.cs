using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Commands;

public record DepositCommand(Guid AccountId, decimal Amount) : ICommand;