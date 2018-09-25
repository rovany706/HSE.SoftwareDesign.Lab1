namespace HSE.SD.Lab1.Identifiers
{
    public class Constant : Identifier
    {
        public object Value;

        public Constant(string name, string type, string usageType, object value) : base(name, type, usageType)
        {
            Value = value;
        }
    }
}
