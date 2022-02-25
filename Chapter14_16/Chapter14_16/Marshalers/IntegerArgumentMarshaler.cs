using System;
using System.Collections.Generic;

namespace Chapter14_16.Marshalers
{
    public class IntegerArgumentMarshaler : ArgumentMarshaler
    {
        private char argumentId;
        private int integerValue = 0;

        public IntegerArgumentMarshaler(char argumentId)
        {
            this.argumentId = argumentId;
        }

        public void set(IEnumerator<string> currentArgument)
        {
            try
            {
                this.integerValue = Int32.Parse(currentArgument.Current);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.MISSING_INTEGER, this.argumentId, currentArgument.Current);
            }
            catch (FormatException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.INVALID_INTEGER, this.argumentId, currentArgument.Current);
            }
        }

        public object get()
        {
            return this.integerValue;
        }
    }
}
