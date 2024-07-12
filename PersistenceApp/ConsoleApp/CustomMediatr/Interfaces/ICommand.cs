namespace ConsoleApp.CustomMediatr.Interfaces;

internal interface ICommand
{
    bool Succeeded { get; set; }
}