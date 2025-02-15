﻿using System.Collections.Generic;

namespace Chapter14_13.Marshalers
{
    public class BooleanArgumentMarshaler : ArgumentMarshaler
    {
        private bool booleanValue = false;

        public void set(IEnumerator<string> currentArgument)
        {
            this.booleanValue = true;
        }

        public object get()
        {
            return this.booleanValue;
        }
    }
}
