using System.Collections.Generic;

namespace Util
{
    public static class ListExtension
    {
        public static List<T> Concat<T>(this List<T> fistList, List<T> secondList)
        {
            foreach (T item in secondList)
            {
                fistList.Add(item);
            }
            return fistList;
        }
    }
}
