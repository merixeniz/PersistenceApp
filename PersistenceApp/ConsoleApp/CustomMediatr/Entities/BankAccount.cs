using ConsoleApp.CustomMediatr.Events;
using ConsoleApp.CustomMediatr.Interfaces;

namespace ConsoleApp.CustomMediatr.Entities;

public class BankAccount : IAggregateRoot
{
    public Guid Id { get; init; }
    public decimal Balance { get; private set; }

    public BankAccount(Guid Id)
    {
        this.Id = Id;
    }

    public bool Apply(DepositedEvent @event)
    {
        if (@event.Amount < 0)
            return false;

        Balance += @event.Amount;
        return true;
    }

    public bool Apply(WithdrawnEvent @event)
    {
        if (Balance < @event.Amount || @event.Amount < 0)
            return false;

        Balance -= @event.Amount;
        return true;
    }

    public bool Apply(TransferredEvent @event)
    {
        if (@event.Amount < 0)
            return false;

        // This method is for cases where the account is the source of the transfer
        if (@event.FromAggregateId == Id)
        {
            if (Balance < @event.Amount) return false;

            Balance -= @event.Amount;
            return true;
        }

        // This method is for cases where the account is the destination of the transfer
        if (@event.ToAggregateId == Id)
            Balance += @event.Amount;

        return true;
    }

    public bool Apply(ReversedEvent @event)
    {
        // Apply logic for reversed events if needed
        Console.WriteLine($"Reversed event applied on BankAccount of id: {Id}");
        return true;
    }

}