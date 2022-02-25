using System.Collections.Generic;

namespace Chapter14_16.Marshalers
{
    public interface ArgumentMarshaler
    {
        void set(IEnumerator<string> currentArgument);

        object get();
    }
}
