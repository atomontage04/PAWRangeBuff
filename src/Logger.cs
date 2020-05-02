using System;

namespace PAWRangeBuff
{
    class Logger
    {
        public static void log(String message)
        {
#if (DEBUG)
            KSPLog.print(string.Format("[PAWRangeBuff] {0}", message));
#endif
        }
    }
}
