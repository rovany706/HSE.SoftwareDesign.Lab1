namespace HSE.SD.Lab1
{
    public class LinearList
    {
        public LinearList Next;
        public object Value;

        public LinearList(object value)
        {
            Next = null;
            Value = value;
        }

        public LinearList Add(object value)
        {
            LinearList newNode = new LinearList(value);

            LinearList i = this;

            while (i.Next != null)
                i = i.Next;
            i.Next = newNode;

            return this;
        }
    }
}
