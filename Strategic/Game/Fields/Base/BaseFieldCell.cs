using Game.Units.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Utils;

namespace Game.Fields.Base
{
    public abstract class BaseFieldCell : IFieldCell
    {
        public abstract string Name { get; }
        public string UniqueName => string.Format("{0}:{1}_{2}", Name, YCoord, XCoord);
        public byte[] Color => UtilFunctions.StringToBytes(ColorCode);
        public abstract int XCoord { get; init; }
        public abstract int YCoord { get; init; }
        public abstract IUnit? Unit { get; set; }

        protected abstract string ColorCode { get; }
        // 性能などを示す（クラス毎に固有で固定の）パラメータをまとめたパラメータクラスを作ってそれを持たせるのでもいいかも
    }
}
