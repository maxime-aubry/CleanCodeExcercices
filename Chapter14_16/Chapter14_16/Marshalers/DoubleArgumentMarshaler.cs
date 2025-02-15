﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace Chapter14_16.Marshalers
{
    public class DoubleArgumentMarshaler : ArgumentMarshaler
    {
        private double doubleValue = 0;

        public void set(IEnumerator<string> currentArgument)
        {
            try
            {
                this.doubleValue = double.Parse(currentArgument.Current, CultureInfo.InvariantCulture);
            }
            catch (ArgumentNullException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.MISSING_DOUBLE, currentArgument.Current);
            }
            catch (FormatException e)
            {
                throw new ArgsException(ArgsException.ErrorCode.INVALID_DOUBLE, currentArgument.Current);
            }
        }

        public object get()
        {
            return this.doubleValue;
        }

        public static double getValue(ArgumentMarshaler am)
        {
            try
            {
                return (am == null) ? 0 : (double)am.get();
            }
            catch (Exception e)
            {
                return 0.0;
            }
        }
    }
}
