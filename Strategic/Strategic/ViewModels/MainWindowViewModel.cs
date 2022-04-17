using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using Game;
using App.Commands;


namespace App.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ICommand DrawCommand { get; init; }

        private BattleField BattleField { get; set; }

        public MainWindowViewModel()
        {
            BattleField = new BattleField();
            
            DrawCommand = new DrawBattleFieldCommand(this);
        }

        public int GetHeight()
        {
            return BattleField.Field.Height;
        }

        public int GetWidth()
        {
            return BattleField.Field.Width;
        }

        private static void ReDrawBattleField(BattleField battleField)
        {
            
        }
    }
}
