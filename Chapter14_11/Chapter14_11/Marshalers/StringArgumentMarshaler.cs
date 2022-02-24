namespace Chapter14_11.Marshalers
{
    public class StringArgumentMarshaler : ArgumentMarshaler
    {
        private string stringValue = "";

        public override void set(string value)
        {
            this.stringValue = value;
        }

        public override object get()
        {
            return this.stringValue;
        }
    }
}
