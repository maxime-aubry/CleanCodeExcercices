using System.Collections.Generic;

namespace Chapter14_14.Marshalers
{
    public interface ArgumentMarshaler
    {
        void set(IEnumerator<string> currentArgument);

        object get();
    }
}
