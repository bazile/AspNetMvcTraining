using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson16
{
    public static class MyExtensions
    {
        public static bool IsOneOf(this string s, params string[] values)
        {
            return values != null && values.Contains(s);
        }
    }
}