using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Fields.Base;
using Game.Units.Base;

namespace Game.Fields
{
    public class Plane : BaseFieldCell
    {
        public override string Name => "Plane";

        public override int XCoord { get; init; }
        public override int YCoord { get; init; }

        protected override string ColorCode => "4DDD5C";

        public override IUnit? Unit { get; set; }

        public Plane(int xcoord, int ycoord)
        {
            XCoord = xcoord;
            YCoord = ycoord;
            Unit = null;
        }

        public Plane(int xcoord, int ycoord, IUnit unit)
        {
            XCoord = xcoord;
            YCoord = ycoord;
            Unit = unit;
        }
    }
}
