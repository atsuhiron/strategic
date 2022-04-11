using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game;
using Game.Players.Base;

namespace Game
{
    public class BattleField
    {
        public Field Field { get; private set; }

        public IPlayer[] Players { get; private set; }

        public BattleField()
        {
            Field = new Field(debug: true);
            Players = Array.Empty<IPlayer>();
        }
    }
}
