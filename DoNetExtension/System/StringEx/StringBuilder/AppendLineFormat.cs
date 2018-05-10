using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static partial class StringEx
    {
        public static void AppendLineFormat(this StringBuilder sb, string format, object arg)
        {
            sb.AppendFormat(format, arg);
            sb.AppendLine();
        }

        public static void AppendLineFormat(this StringBuilder sb, string format, object arg0, object arg1)
        {
            sb.AppendFormat(format, arg0, arg1);
            sb.AppendLine();
        }

        public static void AppendLineFormat(this StringBuilder sb, string format, object arg0, object arg1, object arg2)
        {
            sb.AppendFormat(format, arg0, arg1, arg2);
            sb.AppendLine();
        }

        public static void AppendLineFormat(this StringBuilder sb, IFormatProvider provider, string format, params object[] args)
        {
            sb.AppendFormat(provider, format, args);
            sb.AppendLine();
        }

        public static void AppendLineFormat(this StringBuilder sb, string format, params object[] args)
        {
            sb.AppendFormat(format, args);
            sb.AppendLine();
        }
    }
}
