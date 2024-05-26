using ConsoleApp.CustomMediatr.Commands;
using ConsoleApp.CustomMediatr.Dispatcher;
using ConsoleApp.CustomMediatr.Handlers;
using ConsoleApp.CustomMediatr.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp
{
    internal class DependencyInjection
    {
        public static ServiceProvider InitializeContainer()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddTransient<ICommandHandler<MessageCommand>, MessageCommandHandler>();
            serviceCollection.AddSingleton<ICommandDispatcher, CommandDispatcher>();
            return serviceCollection.BuildServiceProvider();
        }
    }
}
