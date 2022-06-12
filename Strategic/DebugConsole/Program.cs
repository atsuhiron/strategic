using System.Linq;
using System.Text.Json;
using Game.Units;

namespace DebugConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string jstr2 = "{\"ParentName\":\"pare\",\"Samples\":[{\"KlType\":0,\"Name\":\"alpha\",\"SomeValue\":23},{\"KlType\":1,\"Name\":\"bravo\",\"SomeValue\":43},{\"KlType\":0,\"Name\":\"charie\",\"SomeValue\":18}]}";
            Console.WriteLine(jstr2);

            var dict = JsonToDict.ParseJson(jstr2);
            ParseResult<Parent> parseResult = Parent.Parse(dict);

            if (parseResult.IsSuccess)
            {
                Console.WriteLine("PARSE SUCCESS");
                Parent parsed = parseResult.GetNonNullResult(new Parent());
                Console.WriteLine(parsed.ParentName);
                Console.WriteLine(parsed.Samples.Length);
                Console.WriteLine(parsed.Samples[0].ToString());
                Console.WriteLine(parsed.Samples[1].ToString());
                Console.WriteLine(parsed.Samples[2].ToString());
            }
            else
            {
                Console.WriteLine("PARSE FAILED");
            }
        }
    }
}
