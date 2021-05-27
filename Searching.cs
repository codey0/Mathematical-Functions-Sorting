using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFunctionsSearchingSorting
{
    public static class Searching
    {
        public static int LinearSearch(List<double> l, double key)
        {
            int index = -1;

            if (l.Count > 0)
            {
                int i = 0;

                while (i < l.Count && l[i] != key)
                {
                    i++;
                }

                // The value of 'i' can only equal 'l.Count' if 'key' was not found
                if (i < l.Count)
                {
                    index = i;
                }
            }

            return index;
        }

        public static int BinarySearch(List<double> l, double key)
        {
            int index = -1;

            if (l.Count > 0)
            {
                int low = 0;
                int high = l.Count - 1;
                int mid=-1;
                bool found = false;

                while (low <= high && !found)
                {
                    mid = (low + high) / 2;
                    if (l[mid] > key)
                    {
                        high = mid - 1;
                    }
                    else if (l[mid] < key)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        found = true;
                    }
                }

                if (found)
                {
                    index = mid;
                }
            }

            return index;
        }
    }


}
