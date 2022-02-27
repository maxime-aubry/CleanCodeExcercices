using System;
using System.Collections.Generic;

namespace Chapter14_16.Marshalers
{
    public class BooleanArgumentMarshaler : ArgumentMarshaler
    {
        private bool booleanValue = false;

        public void set(IEnumerator<string> currentArgument)
        {
            this.booleanValue = true;
        }

        public object get()
        {
            return this.booleanValue;
        }

        public static bool getValue(ArgumentMarshaler am)
        {
            try
            {
                return (am != null && (bool)am.get());
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
