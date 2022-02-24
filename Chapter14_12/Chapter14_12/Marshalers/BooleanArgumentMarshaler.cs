namespace Chapter14_12.Marshalers
{
    public class BooleanArgumentMarshaler : ArgumentMarshaler
    {
        private bool booleanValue = false;

        public override void set(string value)
        {
            this.booleanValue = true;
        }

        public override object get()
        {
            return this.booleanValue;
        }
    }
}
