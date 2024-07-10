using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Dispatcher;
using ConsoleApp.CustomMediatr.EventStore;
using ConsoleApp.CustomMediatr.Handlers;
using ConsoleApp.CustomMediatr.Interfaces;
using ConsoleApp.CustomMediatr.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp;

internal class DependencyInjection
{
    public static ServiceProvider InitializeContainer()
    {
        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<ICommandHandler<MessageCommand>, MessageCommandHandler>();
        serviceCollection.AddTransient<ICommandHandler<DepositCommand>, DepositCommandHandler>();
        serviceCollection.AddTransient<ICommandHandler<WithdrawCommand>, WithdrawCommandHandler>();
        serviceCollection.AddTransient<ICommandHandler<TransferCommand>, TransferCommandHandler>();
        serviceCollection.AddTransient<ICommandHandler<UndoCommand>, UndoCommandHandler>();

        serviceCollection.AddSingleton<ICommandDispatcher, CommandDispatcher>(); 
        serviceCollection.AddSingleton<IEventStore, InMemoryEventStore>();
        serviceCollection.AddSingleton<IBankAccountRepository, InMemoryBankAccountRepository>();
        return serviceCollection.BuildServiceProvider();
    }
}