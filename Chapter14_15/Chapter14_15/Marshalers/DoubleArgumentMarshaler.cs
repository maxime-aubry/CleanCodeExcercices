using System;
using System.Collections.Generic;

namespace Chapter14_15.Marshalers
{
    public class DoubleArgumentMarshaler : ArgumentMarshaler
    {
        private double doubleValue = 0;

        public void set(IEnumerator<string> currentArgument)
        {
            string parameter = null;
            try
            {
                parameter = currentArgument.Current;
                this.doubleValue = double.Parse(parameter);
            }
            catch (InvalidOperationException e)
            {
                errorCode = ArgsException.ErrorCode.MISSING_DOUBLE;
                throw new ArgsException();
            }
            catch (FormatException e)
            {
                errorParameter = parameter;
                errorCode = ArgsException.ErrorCode.INVALID_DOUBLE;
                throw new ArgsException();
            }
        }

        public object get()
        {
            return this.doubleValue;
        }
    }
}
