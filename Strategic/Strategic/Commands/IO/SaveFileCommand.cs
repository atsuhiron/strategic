using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using App.Commands.IO.Base;
using App.ViewModels;
using App.IO;

namespace App.Commands.IO
{
    public class SaveFileCommand : BaseIOCommand
    {
        public SaveFileCommand(MainWindowViewModel mainWindowVM) : base(mainWindowVM) { }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var filePath = ExecuteFileDialog(new SaveFileDialog(), true, mainWindowViewModel.BattleField.SaveFileName ?? "");
            if (string.IsNullOrEmpty(filePath))
            {
                return;
            }

            SaveDataIO.Write(mainWindowViewModel.BattleField, filePath);
        }
    }
}
