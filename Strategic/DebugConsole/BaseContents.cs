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

    public class Klass1 : IKlass
    {
        public KlassType KlType => KlassType.Type1;
        public string Name { get; set; }
        public int SomeValue { get; set; }

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

    public class Klass2 : IKlass
    {
        public KlassType KlType => KlassType.Type2;
        public string Name { get; set; }
        public int SomeValue { get; set; }

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
}
