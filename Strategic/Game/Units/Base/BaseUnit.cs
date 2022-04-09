using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Units.Base;

namespace Game.Units.Base
{
    public abstract class BaseUnit : IUnit
    {
        public abstract string Name { get; }
        public string UniqueName => string.Format("{0}:{1}_{2}", Name, YCoord, XCoord);
        public abstract uint XCoord { get; set; }
        public abstract uint YCoord { get; set; }
        public abstract string Color { get; }
    }
}
