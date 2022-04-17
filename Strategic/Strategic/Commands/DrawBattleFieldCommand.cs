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

namespace App.Commands
{
    public class DrawBattleFieldCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DrawBattleFieldCommand() { }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is Grid bfGrid)
            {
                var rect = new Rectangle
                {
                    Width = 40,
                    Height = 80,
                    Margin = new Thickness(10, 20, 0, 0),
                    Stroke = new SolidColorBrush(Colors.Blue)
                };
                bfGrid.Children.Add(rect);
            }
        }
    }
}
