using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Units.Base
{
    public interface IUnit
    {
        public string Name { get; }
        public string UniqueName { get; }
        public uint XCoord { get; set; }
        public uint YCoord { get; set; }
        public string Color { get; }
    }
}
