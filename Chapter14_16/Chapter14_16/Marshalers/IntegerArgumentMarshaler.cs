using System;
using System.Collections.Generic;

namespace Chapter14_16.Marshalers
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

        public static int getValue(ArgumentMarshaler am)
        {
            try
            {
                return (am == null) ? 0 : (int)am.get();
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
