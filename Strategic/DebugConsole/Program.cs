using System;
using System.Text.Json;
using Game.Units;

namespace DebugConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(String.Equals(UnitTypes.Infantry.ToString(), "Infantry"));
            
            var parent = new Parent();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jstr = JsonSerializer.Serialize(parent, options);
            Console.WriteLine(jstr);
        }
    }

    internal class Sample
    {
        public string Name { get; set; }
        public int Num { get; set; }

        public Sample(string ss, int nn)
        {
            Name = ss;
            Num = nn;
        }
    }

    internal class Parent
    {
        public string ParentName { get; set; }
        
        public Sample[] Samples { get; set; }

        public Parent()
        {
            ParentName = "pare";
            Samples = new Sample[]
            {
                new Sample("alpha", 23),
                new Sample("bravo", 43),
                new Sample("charie", 18)
            };
        }
    }
}
