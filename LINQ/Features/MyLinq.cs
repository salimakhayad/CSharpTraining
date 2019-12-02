using System;
using System.Collections.Generic;
using System.Text;

namespace Features.Linq
{
    public static class MyLinq
    {
        public static int Count<T>(this IEnumerable<T> sequense)
        {

            var count = 0;
            foreach (var item in sequense)
            {
                count += 1;
            }
            return count;
        }
    }
}
