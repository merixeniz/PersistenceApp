using ConsoleApp.CustomMediatr.Events;

namespace ConsoleApp.CustomMediatr.Entities;

public class BankAccount
{
    public Guid Id { get; init; }
    public decimal Balance { get; private set; }

    public BankAccount(Guid Id)
    {
        this.Id = Id;
    }

    public void Apply(DepositedEvent @event)
    {
        Balance += @event.Amount;
    }

    public void Apply(WithdrawnEvent @event)
    {
        Balance -= @event.Amount;
    }

    public void Apply(TransferredEvent @event)
    {
        // Missing validation
        // This method is for cases where the account is the source of the transfer
        if (@event.FromAggregateId == Id)
            Balance -= @event.Amount;

        // This method is for cases where the account is the destination of the transfer
        if (@event.ToAggregateId == Id)
            Balance += @event.Amount;
    }

    public void Apply(ReversedEvent @event)
    {
        // Apply logic for reversed events if needed
        Console.WriteLine($"Reversed event applied on BankAccount of id: {Id}");
    }

}