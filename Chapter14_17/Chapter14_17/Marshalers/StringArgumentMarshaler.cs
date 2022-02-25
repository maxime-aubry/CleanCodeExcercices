using System;
using System.Collections.Generic;

namespace Chapter14_17.Marshalers
{
    public class StringArgumentMarshaler : ArgumentMarshaler
    {
        private char argumentId;
        private string stringValue = "";

        public void set(IEnumerator<string> currentArgument)
        {
            try
            {
                this.stringValue = currentArgument.Current;
            }
            catch (ArgumentNullException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.MISSING_STRING, this.argumentId, currentArgument.Current);
            }
        }

        public object get()
        {
            return this.stringValue;
        }
    }
}
