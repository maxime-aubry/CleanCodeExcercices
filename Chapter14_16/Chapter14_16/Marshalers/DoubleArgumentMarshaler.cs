using System;
using System.Collections.Generic;
using System.Globalization;

namespace Chapter14_16.Marshalers
{
    public class DoubleArgumentMarshaler : ArgumentMarshaler
    {
        private char argumentId;
        private double doubleValue = 0;

        public DoubleArgumentMarshaler(char argumentId)
        {
            this.argumentId = argumentId;
        }

        public void set(IEnumerator<string> currentArgument)
        {
            try
            {
                this.doubleValue = double.Parse(currentArgument.Current, CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.MISSING_DOUBLE, this.argumentId, currentArgument.Current);
            }
            catch (FormatException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.INVALID_DOUBLE, this.argumentId, currentArgument.Current);
            }
        }

        public object get()
        {
            return this.doubleValue;
        }
    }
}
