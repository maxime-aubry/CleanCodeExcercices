using System;
using System.Collections.Generic;

namespace Chapter14_16.Marshalers
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
            catch (ArgumentNullException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.MISSING_STRING, currentArgument.Current);
            }
        }

        public object get()
        {
            return this.stringValue;
        }

        public static string getValue(ArgumentMarshaler am)
        {
            try
            {
                return (am == null) ? "" : (string)am.get();
            }
            catch (Exception e)
            {
                return "";
            }
        }
    }
}
