namespace Chapter14_11.Marshalers
{
    public abstract class ArgumentMarshaler
    {
        public abstract void set(string value);

        public abstract object get();
    }
}
