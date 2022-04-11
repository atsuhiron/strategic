using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Game;

namespace App.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private BattleField BattleField { get; set; }

        public MainWindowViewModel()
        {
            BattleField = new BattleField();   
        }

        private static void ReDrawBattleField(BattleField battleField)
        {

        }
    }
}
