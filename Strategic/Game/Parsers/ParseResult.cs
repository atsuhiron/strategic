using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Parsers
{
    public class ParseResult<T>
    {
        public T? Result { get; set; }
        public bool IsSuccess { get; set; }

        public T GetNonNullResult(T defaultValue)
        {
            return Result ?? defaultValue;
        }
    }
}
