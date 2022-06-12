namespace DebugConsole
{
    public enum KlassType
    {
        Type1,
        Type2
    }

    public interface IKlass
    {
        public KlassType KlType { get; }
        public string Name { get; set; }
        public int SomeValue { get; set; }
    }

    public class ParseResult<T>
    {
        public T? Result { get; set; }
        public bool IsSuccess { get; set; }

        public T GetNonNullResult(T defaultValue)
        {
            return Result ?? defaultValue;
        }
    }

    public abstract class BaseKlass : IKlass
    {
        public abstract KlassType KlType { get; }
        public abstract string Name { get; set; }
        public abstract int SomeValue { get; set; }

        public static ParseResult<IKlass> Parse(Dictionary<string, object> dict)
        {
            string name;
            if (dict.ContainsKey("Name") && dict["Name"] is string _name)
            {
                name = _name;
            }
            else
            {
                return new ParseResult<IKlass> { IsSuccess = false };
            }

            int someValue;
            if (dict.ContainsKey("SomeValue") && dict["SomeValue"] is decimal _decSomeValue)
            {
                someValue = decimal.ToInt32(_decSomeValue);
            }
            else
            {
                return new ParseResult<IKlass> { IsSuccess = false };
            }

            KlassType klType;
            if (dict.ContainsKey("KlType") && dict["KlType"] is decimal _decKlType)
            {
                klType = (KlassType)Enum.ToObject(typeof(KlassType), decimal.ToInt32(_decKlType));
            }
            else
            {
                return new ParseResult<IKlass> { IsSuccess = false };
            }

            return klType switch
            {
                KlassType.Type1 => new ParseResult<IKlass>
                {
                    IsSuccess = true,
                    Result = new Klass1(name, someValue)
                },
                KlassType.Type2 => new ParseResult<IKlass>
                {
                    IsSuccess = true,
                    Result = new Klass2(name, someValue)
                },
                _ => new ParseResult<IKlass> { IsSuccess = false },
            };
        }
    }

    public class Klass1 : BaseKlass
    {
        public override KlassType KlType => KlassType.Type1;
        public override string Name { get; set; }
        public override int SomeValue { get; set; }

        public Klass1(string name, int someValue)
        {
            Name = name;
            SomeValue = someValue;
        }

        public override string ToString()
        {
            return $"K1 Name: {Name}, SomaValue: {SomeValue}";
        }
    }

    public class Klass2 : BaseKlass
    {
        public override KlassType KlType => KlassType.Type2;
        public override string Name { get; set; }
        public override int SomeValue { get; set; }

        public Klass2(string name, int someValue)
        {
            Name = name;
            SomeValue = someValue;
        }

        public override string ToString()
        {
            return $"K2 Name: {Name}, SomaValue: {SomeValue}";
        }
    }

    internal class Parent
    {
        public string ParentName { get; set; }

        public IKlass[] Samples { get; set; }

        public Parent()
        {
            ParentName = "";
            Samples = Array.Empty<IKlass>();
        }

        public Parent(string parentName, IKlass[] klasses)
        {
            ParentName = parentName;
            Samples = klasses;
        }

        public static ParseResult<Parent> Parse(Dictionary<string, dynamic?> dict)
        {
            string name;
            if (dict.ContainsKey("ParentName") && dict["ParentName"] is string _name)
            {
                name = _name;
            }
            else
            {
                return new ParseResult<Parent> { IsSuccess = false };
            }

            List<object> samples;
            if (dict.ContainsKey("Samples") && dict["Samples"] is List<object> _samples)
            {
                samples = _samples;
            }
            else
            {
                return new ParseResult<Parent> { IsSuccess = false };
            }

            IKlass[] parseResults = samples
                .Where(objSample => objSample is Dictionary<string, object>)
                .Select(objSample => (Dictionary<string, object>)objSample)
                .Select(sample => BaseKlass.Parse(sample))
                .Where(pr => pr.IsSuccess)
                .Select(pr => pr.GetNonNullResult(new Klass1("", 0)))
                .ToArray();

            return new ParseResult<Parent>
            {
                IsSuccess = true,
                Result = new Parent(name, parseResults)
            };
        }
    }
}
