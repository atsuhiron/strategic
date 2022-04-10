using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Units.Base;

namespace Game.Fields.Base
{
    public interface IBuilding
    {
        public int ExtraCapacity { get; }

        public List<IUnit> ExtraUnits { get; set; }

        public void CarryIn(IUnit unit);

        public IUnit CarryOut(uint index);
    }
}
