using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Text
{
    public partial class StringReader
    {
        bool _innerSeekTo(int keyPos, int advance, bool skipKey, bool seekToEndIfKeyNotFound)
        {
            if (keyPos == -1)
            {
                if (seekToEndIfKeyNotFound) CurrentPosition = EndPosition;
                return false;
            }
            else
            {
                if (skipKey) CurrentPosition = keyPos + advance;
                else CurrentPosition = keyPos;
                return true;
            }
        }
    }
}
