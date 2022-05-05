using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using App.Commands.IO.Base;
using App.IO;
using App.ViewModels;

namespace App.Commands.IO
{
    public class LoadFileCommand : BaseIOCommand
    {
        public LoadFileCommand(MainWindowViewModel mainWindowVM) : base(mainWindowVM) { }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var filePath = ExecuteFileDialog(new OpenFileDialog(), false);
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            var readResult = SaveDataIO.ReadSync(filePath);
            if (!readResult.Item1 || readResult.Item2 == null)
            {
                return;
            }

            mainWindowViewModel.BattleField = readResult.Item2;
            mainWindowViewModel.BattleField.SaveFileName = GetBaseName(filePath);

            mainWindowViewModel.RedrawCommand.Execute(parameter);
        }

        private static string GetBaseName(string fullPath)
        {
            return fullPath.Split('\\').Last();
        }
    }
}
