using System.Collections.Generic;

namespace ModuleHW
{
    public class TComparer<T> : IComparer<T>
    {
        public int Compare(T x, T y)
        {
            if (x != null && y != null)
            {
                if (x is int && y is int)
                {
                    var intX = x as int?;
                    var intY = y as int?;

                    if (intX > intY)
                    {
                        return 1;
                    }
                    else if (intX < intY)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }

                if (x is string && y is string)
                {
                    var xChars = (x as string).ToCharArray();
                    var yChars = (y as string).ToCharArray();

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

                return 0;
            }
            else
            {
                return 0;
            }
        }
    }
}
