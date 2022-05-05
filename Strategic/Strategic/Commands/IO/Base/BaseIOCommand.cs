using System;
using System.Windows.Input;
using Microsoft.Win32;
using App.Constants;
using App.ViewModels;

namespace App.Commands.IO.Base
{
    public abstract class BaseIOCommand : ICommand
    {
        protected readonly MainWindowViewModel mainWindowViewModel;

        public BaseIOCommand(MainWindowViewModel mainWindowVM)
        {
            mainWindowViewModel = mainWindowVM;
        }

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object? parameter);
        public abstract void Execute(object? parameter);

        protected static string ExecuteFileDialog(FileDialog dialog, bool genDefaultName, string defaultName = "")
        {
            //参考文献：
            //https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/windows/how-to-open-common-system-dialog-box?view=netdesktop-6.0
            //https://code-examples.net/ja/q/18b631
            //https://qiita.com/mikurisa/items/709d24e53b29c4839c67

            if (genDefaultName)
            {
                dialog.FileName = GenDefaultFileName();
            }
            else
            {
                dialog.FileName = defaultName;
            }
            
            dialog.DefaultExt = ".json";
            dialog.Filter = "Text documents (.json)|*.json";
            bool? result = dialog.ShowDialog();

            if (result ?? false) return dialog.FileName;
            return string.Empty;
        }

        private static string GenDefaultFileName()
        {
            return DateTime.Now.ToString(Values.DefaultSaveFileNameFormat);
        }
        
    }
}
