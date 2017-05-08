using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NewLeafWebScraper
{
    public static class Extensions
    {
        public static string RemoveAllWhitespace(this string s)
        {
            return Regex.Replace(s, @"\s+", "");
        }
    }
}
