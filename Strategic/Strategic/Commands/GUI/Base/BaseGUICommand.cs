using System;
using System.Windows.Input;
using App.ViewModels;

namespace App.Commands.GUI.Base
{
    public abstract class BaseGUICommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        protected readonly MainWindowViewModel mainWindowViewModel;

        public BaseGUICommand(MainWindowViewModel mainWindowVM)
        {
            mainWindowViewModel = mainWindowVM;
        }

        public abstract bool CanExecute(object? parameter);
        public abstract void Execute(object? parameter);
    }
}
