using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Units.Base;

namespace Game.Fields.Base
{
    public interface IFieldCell
    {
        public string Name { get; }
        public string UniqueName { get; }
        public string Color { get; }
        public uint XCoord { get; init; }
        public uint YCoord { get; init; }
        public IUnit? Unit { get; set; }
        
    }
}
