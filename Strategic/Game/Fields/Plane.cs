using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Fields.Base;

namespace Game.Fields
{
    public class Plane : BaseFieldCell
    {
        public override string Name => "Plane";

        public override uint XCoord { get; init; }
        public override uint YCoord { get; init; }

        public override string Color => "Green";
    }
}
