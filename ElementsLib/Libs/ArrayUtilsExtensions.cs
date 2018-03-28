using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Libs
{
    public static class ArrayUtilsExtensions
    {
        public static IEnumerable<T> Merge<T>(this IEnumerable<T> array, T value)
        {
            return array.Concat(new T[] { value });
        }
    }
}
