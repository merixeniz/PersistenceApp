namespace ConsoleApp.CustomMediatr.Interfaces;

internal interface ICommandDispatcher
{
    //public void Dispatch<T>(T command) where T : ICommand;
    public Task DispatchAsync<T>(T command) where T : ICommand;
}