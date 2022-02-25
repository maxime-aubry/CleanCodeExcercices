using System.Collections.Generic;

namespace Chapter14_16.Marshalers
{
    public class BooleanArgumentMarshaler : ArgumentMarshaler
    {
        private char argumentId;
        private bool booleanValue = false;

        public BooleanArgumentMarshaler(char argumentId)
        {
            this.argumentId = argumentId;
        }

        public void set(IEnumerator<string> currentArgument)
        {
            this.booleanValue = true;
        }

        public object get()
        {
            return this.booleanValue;
        }
    }
}
