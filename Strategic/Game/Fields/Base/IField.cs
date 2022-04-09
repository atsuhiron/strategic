using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Fields.Base
{
    public interface IField
    {
        public uint Width { get; init; }
        public uint Height { get; init; }
        public IReadOnlyList<IReadOnlyList<IFieldCell>> FieldCells { get; init; }
    }
}
