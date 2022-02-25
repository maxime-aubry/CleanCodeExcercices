using System.Collections.Generic;

namespace Chapter14_17.Marshalers
{
    public class BooleanArgumentMarshaler : ArgumentMarshaler
    {
        private char argumentId;
        private bool booleanValue = false;

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
