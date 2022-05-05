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
using App.Commands.IO;


namespace App.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        #region commands
        public ICommand RedrawCommand { get; init; }
        //public ICommand DrawCommand { get; init; }
        public ICommand IOLoadCommand { get; init; }
        public ICommand IOSaveCommand { get; init; }
        #endregion

        #region models
        private BattleField _battleField;
        public BattleField BattleField
        { 
            get
            {
                return _battleField; 
            } 
            set
            {
                _battleField = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BattleField)));
                // DrawコマンドとRedrawコマンドを分けて、ここではDrawの方を呼ぶ
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            BattleField = new BattleField();
            
            RedrawCommand = new RedrawBattleFieldCommand(this);
            IOLoadCommand = new LoadFileCommand(this);
            IOSaveCommand = new SaveFileCommand(this);
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
