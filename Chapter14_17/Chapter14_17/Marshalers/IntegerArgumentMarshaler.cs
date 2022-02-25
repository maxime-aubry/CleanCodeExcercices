using System;
using System.Collections.Generic;

namespace Chapter14_17.Marshalers
{
    public class IntegerArgumentMarshaler : ArgumentMarshaler
    {
        private int integerValue = 0;

        public void set(IEnumerator<string> currentArgument)
        {
            try
            {
                this.integerValue = Int32.Parse(currentArgument.Current);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.MISSING_INTEGER, currentArgument.Current);
            }
            catch (FormatException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.INVALID_INTEGER, currentArgument.Current);
            }
        }

        public object get()
        {
            return this.integerValue;
        }
    }
}
