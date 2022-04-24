using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App.Constants;

namespace App.Commands.IO.Base
{
    public abstract class BaseIOCommand : ICommand
    {
        protected string DefaultPath => Paths.saveDataDir;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object? parameter);
        public abstract void Execute(object? parameter);
    }
}
