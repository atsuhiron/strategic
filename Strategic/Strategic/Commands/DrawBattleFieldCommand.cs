﻿using System;
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
using Game.Fields;

namespace App.Commands
{
    public class DrawBattleFieldCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        private readonly MainWindowViewModel mainWindowViewModel;

        public DrawBattleFieldCommand(MainWindowViewModel mainWindowVM)
        {
            mainWindowViewModel = mainWindowVM;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
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
