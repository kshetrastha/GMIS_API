using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Common.Helper
{
    public class StringHelper
    {
        static readonly string[] _sqlDangerousChars = new string[]
        {
            "--",
            "/*",
            "*/",
            "'",
            ";",
            "\r",
            "\n"
        };

        public static string FilterSQLDangerousString(string strToFilter)
        {
            if (string.IsNullOrEmpty(strToFilter))
                return string.Empty;

            foreach (string i in _sqlDangerousChars)
            {
                strToFilter = strToFilter.Replace(i, string.Empty);
            }

            return strToFilter;
        }

        public static bool ContainsSQLDangerousString(string strToFilter)
        {
            if (string.IsNullOrEmpty(strToFilter))
                return false;

            foreach (string i in _sqlDangerousChars)
            {
                if (strToFilter.Contains(i))
                    return true;
            }

            return false;
        }

        static readonly string[] webInvStrings = new string[] { "..", "&" };
        public static string RemoveInvalidFileNameChar(string fileName)
        {
            char[] invChars = System.IO.Path.GetInvalidFileNameChars();

            int len = 0;
            while (len < fileName.Length)
            {
                if (invChars.Contains(fileName[len]))
                    fileName = fileName.Remove(len, 1);
                else
                    ++len;
            }

            foreach (string i in webInvStrings)
            {
                fileName = fileName.Replace(i, string.Empty);
            }
            return fileName;
        }

        public static string SafeSubString(string str, int length)
        {
            if (str == null)
                return string.Empty;

            if (str.Length > length)
                return str.Substring(0, length);
            else
                return str;
        }

        public static string AddQueryStringToUrl(string url, string qsname, string qsvalue)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException("The specified url is invalid.");

            if (!string.IsNullOrWhiteSpace(qsname))
            {
                if (url.IndexOf('?') >= 0)
                {
                    url += '&' + qsname + '=' + qsvalue;
                }
                else
                {
                    url += '?' + qsname + '=' + qsvalue;
                }

                return url;
            }
            else
                throw new ArgumentException("Query string name can not be null or empty.");
        }

        public static string DefaultIfNull(string str, string defaultVal = "")
        {
            if (str == null)
                return defaultVal;

            return str;
        }
    }

    class CaseInsensitiveStringEqualityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.Equals(y, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(string obj)
        {
            if (obj == null)
                throw new ArgumentNullException("The specified string can not be null.");

            return obj.ToLower().GetHashCode();
        }
    }
}
