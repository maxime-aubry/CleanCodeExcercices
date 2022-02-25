using System;
using System.Collections.Generic;

namespace Chapter14_13.Marshalers
{
    public class StringArgumentMarshaler : ArgumentMarshaler
    {
        private string stringValue = "";

        public void set(IEnumerator<string> currentArgument)
        {
            try
            {
                this.stringValue = currentArgument.Current;
            }
            catch (InvalidOperationException e)
            {
                errorCode = ArgsException.ErrorCode.MISSING_STRING;
                throw new ArgsException();
            }
        }

        public object get()
        {
            return this.stringValue;
        }
    }
}
