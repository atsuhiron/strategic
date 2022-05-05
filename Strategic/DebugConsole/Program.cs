using System;
using System.Text.Json;
using Game.Units;

namespace DebugConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //Console.WriteLine(String.Equals(UnitTypes.Infantry.ToString(), "Infantry"));

            //var datetime = DateTime.Now;
            //Console.WriteLine(datetime.ToString("yyyyMMddhhmmss"));
            string jstr2 = "{\"ParentName\":\"pare\",\"Samples\":[{\"Name\":\"alpha\",\"SomeValue\":23},{\"Name\":\"bravo\",\"SomeValue\":43},{\"Name\":\"charie\",\"SomeValue\":18}]}";
            Parent? parent2 = JsonSerializer.Deserialize<Parent>(jstr2);

            var parent = new Parent();
            var options = new JsonSerializerOptions { WriteIndented = false };
            string jstr = JsonSerializer.Serialize(parent, options);
            Console.WriteLine(parent2?.Samples[0].ToString());
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
            ParentName = "pare";
            Samples = new IKlass[]
            {
                new Klass("alpha", 23),
                new Klass("bravo", 43),
                new Klass("charie", 18)
            };
        }
    }
}
