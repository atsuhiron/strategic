using System;
using Game.Units;

namespace DebugConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(String.Equals(UnitTypes.Infantry.ToString(), "Infantry"));
        }
    }
}
