using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.CustomMediatr.Interfaces
{
    internal interface ICommandDispatcher
    {
        public void Dispatch<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
