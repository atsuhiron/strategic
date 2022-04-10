using Game.Units.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Fields.Base
{
    public abstract class BaseFieldCell : IFieldCell
    {
        public abstract string Name { get; }
        public string UniqueName => string.Format("{0}:{1}_{2}", Name, YCoord, XCoord);
        public abstract string Color { get; }
        public abstract uint XCoord { get; init; }
        public abstract uint YCoord { get; init; }
        public abstract IUnit? Unit { get; set; }
    }
}
