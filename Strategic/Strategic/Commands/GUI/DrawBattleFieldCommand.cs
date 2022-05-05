using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using App.Commands.GUI.Base;
using App.ViewModels;
using App.Constants;
using App.UIEFactories;
using Game.Fields;

namespace App.Commands.GUI
{
    public class DrawBattleFieldCommand : BaseGUICommand
    {
        public DrawBattleFieldCommand(MainWindowViewModel mainWindowVM) : base(mainWindowVM) { }

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            // グリッドと変更箇所の座標を渡す？
        }
    }
}
