using System;
using System.Text.Json;
using Game.Units;

namespace DebugConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jstr2 = "{\"ParentName\":\"pare\",\"Samples\":[{\"KlType\":0,\"Name\":\"alpha\",\"SomeValue\":23},{\"KlType\":1,\"Name\":\"bravo\",\"SomeValue\":43},{\"KlType\":0,\"Name\":\"charie\",\"SomeValue\":18}]}";

            var dict = JsonToDict.ParseJson(jstr2);

            Console.WriteLine(dict.ContainsKey("ParentName"));
            // ここから頑張ればなんとかなりそう
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
        
        public IKlass[] Samples { get; set; }

        public Parent()
        {
            ParentName = "";
            Samples = new IKlass[0];
        }

        public Parent(string parentName, IKlass[] klasses)
        {
            ParentName = parentName;
            Samples = klasses;
        }
    }
}
