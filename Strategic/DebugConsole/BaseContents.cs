using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebugConsole
{
    public interface IKlass
    {
        public string Name { get; set; }
        public int SomeValue { get; set; }
    }

    public class Klass : IKlass
    {
        public string Name { get; set; }
        public int SomeValue { get; set; }

        public Klass(string name, int someValue)
        {
            Name = name;
            SomeValue = someValue;
        }

        public override string ToString()
        {
            return $"Name: {Name}, SomaValue: {SomeValue}";
        }
    }
}
