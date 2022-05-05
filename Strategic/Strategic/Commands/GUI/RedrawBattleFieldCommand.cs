using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using App.ViewModels;
using App.Constants;
using App.UIEFactories;
using App.Commands.GUI.Base;
using Game.Fields;

namespace App.Commands
{
    public class RedrawBattleFieldCommand : BaseGUICommand
    {
        public RedrawBattleFieldCommand(MainWindowViewModel mainWindowVM): base(mainWindowVM) {}

        public override bool CanExecute(object? parameter)
        {
            return true;
        }

        public override void Execute(object? parameter)
        {
            var width = mainWindowViewModel.GetWidth();
            var height = mainWindowViewModel.GetHeight();
            if (parameter is Grid bfGrid)
            {
                foreach (var y in Enumerable.Range(0, height))
                {
                    foreach (var x in Enumerable.Range(0, width))
                    {
                        var rect = FieldCellFactory.CreateFieldCell(new Plane(x, y));
                        bfGrid.Children.Add(rect);
                    }
                }
                bfGrid.Width = Values.cellSize * width;
                bfGrid.Height = Values.cellSize * height;                
            }
        }
    }
}
