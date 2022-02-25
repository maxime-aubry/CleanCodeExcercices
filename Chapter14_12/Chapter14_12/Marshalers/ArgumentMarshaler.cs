using System.Collections.Generic;

namespace Chapter14_12.Marshalers
{
    public interface ArgumentMarshaler
    {
        void set(IEnumerator<string> currentArgument);

        object get();
    }
}
