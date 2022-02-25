using System;
using System.Collections.Generic;

namespace Chapter14_15.Marshalers
{
    public class IntegerArgumentMarshaler : ArgumentMarshaler
    {
        private int integerValue = 0;

        public void set(IEnumerator<string> currentArgument)
        {
            string parameter = null;
            try
            {
                parameter = currentArgument.Current;
                this.integerValue = Int32.Parse(parameter);
            }
            catch (InvalidOperationException e)
            {
                errorCode = ArgsException.ErrorCode.MISSING_INTEGER;
                throw new ArgsException();
            }
            catch (FormatException e)
            {
                errorParameter = parameter;
                errorCode = ArgsException.ErrorCode.INVALID_INTEGER;
                throw new ArgsException();
            }
        }

        public object get()
        {
            return this.integerValue;
        }
    }
}
