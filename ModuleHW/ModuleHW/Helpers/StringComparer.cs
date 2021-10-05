using System.Collections.Generic;

namespace ModuleHW
{
    public class StringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var xChars = x.ToCharArray();
            var yChars = y.ToCharArray();

            var length = xChars.Length <= yChars.Length ? xChars.Length : yChars.Length;

            for (var i = 0; i < length; i++)
            {
                if (xChars[i] > yChars[i])
                {
                    return 1;
                }
                else if (xChars[i] < yChars[i])
                {
                    return -1;
                }
            }

            if (xChars.Length != yChars.Length)
            {
                return xChars.Length < yChars.Length ? 1 : -1;
            }

            return 0;
        }
    }
}
