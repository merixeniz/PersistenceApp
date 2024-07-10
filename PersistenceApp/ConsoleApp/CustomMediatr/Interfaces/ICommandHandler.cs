namespace ConsoleApp.CustomMediatr.Interfaces;

internal interface ICommandHandler<T> where T : ICommand
{
    //public void Handle<TCommand>(TCommand command) where TCommand : ICommand;
    public Task HandleAsync(T command);
}