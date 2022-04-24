using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using App.Commands.IO.Base;

namespace App.Commands.IO
{
    public class LoadFileCommand : BaseIOCommand
    {
        public override bool CanExecute(object? parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object? parameter)
        {
            throw new NotImplementedException();
        }

        private string ExecuteOpenFileDialog()
        {
            var dialog = new OpenFileDialog { InitialDirectory = DefaultPath };
            dialog.ShowDialog();

            return dialog.FileName;
        }
        //参考文献：
        //https://docs.microsoft.com/ja-jp/dotnet/desktop/wpf/windows/how-to-open-common-system-dialog-box?view=netdesktop-6.0
        //https://code-examples.net/ja/q/18b631
        //https://qiita.com/mikurisa/items/709d24e53b29c4839c67
    }
}
