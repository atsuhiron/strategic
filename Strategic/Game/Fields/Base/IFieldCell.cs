using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Fields.Base
{
    public interface IFieldCell
    {
        public uint XCoord { get; init; }
        public uint YCoord { get; init; }

        string GetColor();
    }
}
