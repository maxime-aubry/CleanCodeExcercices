﻿using System;
using static Chapter14_11.Args;

namespace Chapter14_11.Marshalers
{
    public class IntegerArgumentMarshaler : ArgumentMarshaler
    {
        private int integerValue;

        public override void set(string value)
        {
            try
            {
                this.integerValue = Int32.Parse(value);
            }
            catch (FormatException e)
            {
                throw new ArgsException();
            }
        }

        public override object get()
        {
            return this.integerValue;
        }
    }
}
