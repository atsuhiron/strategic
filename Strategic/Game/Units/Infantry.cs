using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Units.Base;

namespace Game.Units
{
    public class Infantry : BaseUnit
    {
        public override UnitTypes UnitType => UnitTypes.Infantry;

        public override uint XCoord { get; set; }
        public override uint YCoord { get; set; }

        public override string Color => "Blue";
    }
}
