using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathematicalFunctionsSearchingSorting
{
    public static class MathFunctions
    {
      
        #region Measures of Central Tendency

        /// <summary>
        /// 'ArithmeticMean' returns the arithmetic mean (average) of a list of double values.
        /// If the list is empty, NaN is returned.
        /// </summary>
        /// 
        public static double ArithmeticMean(List<double> l)
        {
            double average = Double.NaN;

            // If the numbers in 'l' are very large, there is a risk that summing them will cause numeric  
            // overflow (i.e. the sum is greater than the largest value that can be represented as a double
            // or the sum is smaller than the smallest negative value that can be represented as a double).
            // Double.MaxValue = 1.79769313486232E+308 (1.79769313486232 x 10^308)
            // Double.MinValue = -1.79769313486232E+308 (-1.79769313486232 x 10^308)
            // See https://stackoverflow.com/questions/1930454/what-is-a-good-solution-for-calculating-an-average-where-the-sum-of-all-values-e  
            // for a good discussion on how this problem can be tackled. The code examples are written in Java but
            // should be accessible to anyone with a working knowledge of C#.

            if (l.Count > 0)
            {
                double sum = 0;

                for (int i = 0; i < l.Count; i++)
                {
                    sum += l[i]; //Adding 'l[i]' to 'sum' could result in numeric overflow
                }
                average = sum / l.Count;
            }

            return average;
        }

        // The next procedure illustrates an important principle of object-oriented programming (OOP)
        // known as OVERLOADING. Multiple procedures (called "methods" when they are defined 
        // within classes) can have the SAME NAME as long as their parameters differ in either
        // NUMBER or TYPE.

        /// <summary>
        /// 'ArithmeticMean' returns the arithmetic mean (average) of an array of double values.
        /// </summary>

        public static double ArithmeticMean(double[] a)
        {
            // Unlike lists, arrays cannot be empty. Therefore, there is no need to check whether 
            // 'a' is empty. The number of elements in an array must be specified when the array
            // is created and naturally, the number of elements must be a positive whole number.

            double sum = 0;

            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i]; //Adding 'a[i]' to 'sum' could result in numeric overflow
            }

            return sum / a.Length;
        }


        /// <summary>
        /// 'Median' returns the median of a list of double values.
        /// If the list is empty, NaN is returned.
        /// </summary>

        public static double Median(List<double> l)
        {
            double median = Double.NaN;

            if (l.Count > 0)
            {
                int middle = l.Count / 2;

                // Calculate median for odd number of items
                median = QuickSelect(l, middle + 1, 0, l.Count - 1);
                
                // Adjust the result if number of items is even
                if (l.Count % 2 == 0) 
                {
                    median = (QuickSelect(l, middle, 0, l.Count - 1) + median) / 2;
                }
            }

            return median;
        }

        /// <summary>
        /// 'Median' returns the median of an array of double values.
        /// </summary>

        //public static double Median(double[] a)


        /// <summary>
        /// 'Mode' finds all modes of a list of double values.
        /// </summary>

        public static List<double> Mode(List<double> l)
        {
            List<double> modeList = new List<double>();

            if (l.Count > 0)
            {
                List<double> valueList = new List<double>();
                List<int> frequencyList = new List<int>();

                // Build value and frequency lists
                for (int i = 0; i < l.Count; i++)
                {
                    int index = valueList.IndexOf(l[i]);

                    if (index >= 0) // Value already exists in 'valueList'
                    {
                        frequencyList[index]++;
                    }
                    else // New value found
                    {
                        valueList.Add(l[i]);
                        frequencyList.Add(1);
                    }
                } //end for

                // Build mode list
                int maxFrequency = (int)Maximum(frequencyList); // Force conversion from 'long' to 'int'

                for (int i = 0; i < valueList.Count; i++)
                {
                    if (frequencyList[i] == maxFrequency)
                    {
                        modeList.Add(valueList[i]);
                    }
                }

                modeList.Sort();
            }

            return modeList;
        }

        /// <summary>
        /// 'GeometricMean' returns the geometric mean of a list of double values.
        /// If the list of double values contains any nonpositive values 
        /// (i.e. values that are <= 0) or if the list is empty, NaN is returned.
        /// </summary>

        public static double GeometricMean(List<double> l)
        {
            double geometricMean = Double.NaN;

            // If the numbers in 'l' are large enough, the product l[0] x l[1] x ... x l[n-1], where n=l.Count, could 
            // result in numeric overflow. To prevent this from happening, it is better to calculate the geometric
            // mean by exploiting properties of logarithms: (1) log(x^n) = nlog(x)    (2) log(xy) = log(x) + log(y)
            //
            // GM = nth root of (l[0] x l[1] x ... x l[n-1])  (GM = geometric mean)
            //    = (l[0] x l[1] x ... x l[n-1])^(1/n)
            //
            // Therefore, log(GM) = log((l[0] x l[1] x ... x l[n-1])^(1/n))
            //                    = (1/n)log(l[0] x l[1] x ... x l[n-1])
            //                    = (1/n)(log(l[0]) + log(l[1]) + ... + log(l[n-1]))
            //                    = (log(l[0]) + log(l[1]) + ... + log(l[n-1])) / n
            // Then GM = base^((log(l[0]) + log(l[1]) + ... + log(l[n-1])) / n), where 'base' is the base used for log.
            //
            // Although this method prevents overflow, it could be susceptible to other problems such as 
            // (1) UNDERFLOW (i.e. produce values that are taken to be zero because they are smaller than the
            //     smallest value that can be represented as a double).
            // (2) Evaluating the logarithm is an "expensive" operation for the CPU
            //
            // Double.Epsilon = 4.94065645841247E-324 = 4.94065645841247 x 10^(-324) = smallest positive value that
            // can be represented as a double
            // -Double.Epsilon = -4.94065645841247E-324 = -4.94065645841247 x 10^(-324) = largest negative value 
            // that can be represented as a double.
            // Any value between -Double.Epsilon and Double.Epsilon is taken to be zero

            if (l.Count > 0)
            {
                double sumOfLogs = 0;

                for (int i = 0; i < l.Count; i++)
                {
                    if (l[i] <= 0) // Geometric mean only defined for sets of positive values
                    {
                        return Double.NaN; // Abort the process and return NaN
                    }
                    // Base of 'Log' is 'e', Euler's number, which is 2.71828182845905, correct to 14 decimal places
                    sumOfLogs += Math.Log(l[i]); //Adding 'Log(l[i])' to 'sumOfLogs' CANNOT result in numeric overflow
                }

                // 'E' is a constant within the 'Math' class. It represents Euler's number.
                geometricMean = Math.Pow(Math.E, sumOfLogs / l.Count);
            }

            return geometricMean;
        }

        /// <summary>
        /// 'HarmonicMean' returns the harmonic mean of a list of double values.
        /// If the list of double values contains any nonpositive values 
        /// (i.e. values that are <= 0) or if the list is empty, NaN is returned.
        /// </summary>
        public static double HarmonicMean(List<double> l)
        {
            double harmonicMean = Double.NaN;

            // Let n = l.Count and HM stand for "Harmonic Mean"
            // Then HM = n/(1/l[0] + 1/l[1] + ... + 1/l[n-1]) = n/(sum of reciprocals of values)
            // Overflow and underflow can be an issue for harmonic mean but it's less likely than
            // it is for geometric mean. If the values in the list are very large, then their reciprocals
            // are very small, making the sum of the reciprocals small. Dividing 'n' by a small value
            // can cause overflow in theory but only if 'n' is extremely large. In practice, 'n' has to be 
            // relatively small because of memory limitations. Overflow is more likely to happen if the 
            // values in 'l' are extremely small. For example, if one of the values in the list is Double.Epsilon,
            // then 1/Double.Epsilon = 1/(4.94065645841247E-324) = [4.94065645841247 x 10^(-324)]^(-1)
            // = (4.94065645841247)^(-1) x 10^[(-324)(-1)] > 5^(-1) x 10^324 = 0.2 x 10^324 = 2 x 10^323, which is
            // far greater than the largest double value.

            if (l.Count > 0)
            {
                double sumOfReciprocals = 0;

                for (int i = 0; i < l.Count; i++)
                {
                    if (l[i] <= 0) // Harmonic mean is only defined for positive values.
                    {
                        return Double.NaN; // Abort the process and return NaN
                    }

                    sumOfReciprocals += 1 / l[i];
                }

                harmonicMean = l.Count / sumOfReciprocals;
            }

            return harmonicMean;
        }

        #endregion

        #region Min and Max
        /// <summary>
        /// "Minimum" Overload 1
        /// "Minimum" returns the smallest double value found in a given list of double values.
        /// If the list is empty, NaN is returned.
        /// </summary>

        public static double Minimum(List<double> l)
        {
            double min = Double.NaN;

            if (l.Count > 0)
            {
                min = l[0];

                for (int i = 1; i < l.Count; i++)
                {
                    if (l[i] < min)
                    {
                        min = l[i];
                    }
                }
            }

            return min;
        }

        /// <summary>
        /// "Minimum" Overload 2
        /// "Minimum" returns the smallest double value found in a given array of double values.
        /// </summary>

        public static double Minimum(double[] a)
        {
            double min = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }

            return min;
        }

        /// <summary>
        /// "Minimum" Overload 3
        /// "Minimum" returns the smallest int value found in a given list of int values.
        /// If the list is empty, Int64.MaxValue is returned (because this value is larger than
        /// all int (Int32) values). 
        /// </summary>
        public static long Minimum(List<int> l)
        {
            // 'long' data type is used to ensure that this method will work   
            // even when Int32.MaxValue is the smallest value in the list.
            long min = Int64.MaxValue;

            if (l.Count > 0)
            {
                min = l[0];

                for (int i = 1; i < l.Count; i++)
                {
                    if (l[i] < min)
                    {
                        min = l[i];
                    }
                }
            }

            return min;
        }

        /// <summary>
        /// "IndexOfMinimum" Overload 1
        /// "IndexOfMinimum" returns the index of the smallest double value found in a list of double values.
        /// If the list is empty, -1 is returned.
        /// </summary>

        public static int IndexOfMinimum(List<double> l)
        {
            int indexOfMin = -1;

            if (l.Count > 0)
            {
                indexOfMin = 0;

                for (int i = 1; i < l.Count; i++)
                {
                    if (l[i] < l[indexOfMin])
                    {
                        indexOfMin = i;
                    }
                }
            }

            return indexOfMin;
        }

        /// <summary>
        /// "IndexOfMinimum" Overload 2
        /// "IndexOfMinimum" returns the index of the smallest double value found in the sublist of a  
        /// list of double values starting at index 'startIndex' and ending at index "l.Count-1".
        /// If the list is empty, -1 is returned.
        /// </summary>
        /// 
        public static int IndexOfMinimum(List<double> l, int startIndex)
        {
            int minIndex = -1;

            if (l.Count > 0)
            {
                for (int i = startIndex + 1; i < l.Count; i++)
                {
                    if (l[i] < l[minIndex])
                    {
                        minIndex = i;
                    }
                }
            }

            return minIndex;
        }

        /// <summary>
        /// "IndexOfMinimum" Overload 3
        /// "IndexOfMinimum" returns the index of the smallest double value found in the sublist of a  
        /// list of double values starting at index 'startIndex' and ending at 'endIndex'.
        /// If the list is empty, -1 is returned.
        /// </summary>

        public static int IndexOfMinimum(List<double> l, int startIndex, int endIndex)
        {
            int indexOfMin = -1;

            if (l.Count > 0)
            {
                indexOfMin = startIndex;

                for (int i = startIndex + 1; i <= endIndex; i++)
                {
                    if (l[i] < l[indexOfMin])
                    {
                        indexOfMin = i;
                    }
                }
            }

            return indexOfMin;
        }


        /// <summary>
        /// "Maximum" Overload 1
        /// "Maximum" returns the largest double value found in a given list of double values.
        /// If the list is empty, NaN is returned.
        /// </summary>
        public static double Maximum(List<double> l)
        {
            double max = Double.NaN;

            if (l.Count > 0)
            {
                max = l[0];

                for (int i = 1; i < l.Count; i++)
                {
                    if (l[i] > max)
                    {
                        max = l[i];
                    }
                }
            }

            return max;
        }

        /// <summary>
        /// "Maximum" Overload 2
        /// "Maximum" returns the largest double value found in a given array of double values.
        /// </summary>
        public static double Maximum(double[] a)
        {
            double max = a[0];

            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }

            return max;
        }

        /// <summary>
        /// "Maximum" Overload 3
        /// "Maximum" returns the largest int value found in a given list of int values.
        /// If the list is empty, Int64.MinValue is returned (because this value is smaller than
        /// all Int32 values). 
        /// </summary>
        public static long Maximum(List<int> l)
        {
            // 'long' data type is used to ensure that this method will work   
            // even when Int32.MinValue is the largest value in the list.
            long max = Int64.MinValue;

            if (l.Count > 0)
            {
                max = l[0];

                for (int i = 1; i < l.Count; i++)
                {
                    if (l[i] > max)
                    {
                        max = l[i];
                    }
                }
            }

            return max;
        }

        /// <summary>
        /// "IndexOfMaximum" Overload 1
        /// "IndexOfMaximum" returns the index of the largest double value found in a list of double values.
        /// If the list is empty, -1 is returned.
        /// </summary>
        public static int IndexOfMaximum(List<double> l)
        {
            int indexOfMax = -1;

            if (l.Count > 0)
            {
                indexOfMax = 0;

                for (int i = 1; i < l.Count; i++)
                {
                    if (l[i] > l[indexOfMax])
                    {
                        indexOfMax = i;
                    }
                }
            }

            return indexOfMax;
        }

        /// <summary>
        /// "IndexOfMaximum" Overload 2
        /// "IndexOfMaximum" returns the index of the largest double value found in the sublist of a  
        /// list of double values starting at index 'startIndex' and ending at index "l.Count-1".
        /// If the list is empty, -1 is returned.
        /// </summary>
        public static int IndexOfMaximum(List<double> l, int startIndex)
        {
            int maxIndex = -1;

            if (l.Count > 0)
            {
                for (int i = startIndex + 1; i < l.Count; i++)
                {
                    if (l[i] > l[maxIndex])
                    {
                        maxIndex = i;
                    }
                }
            }

            return maxIndex;
        }

        /// <summary>
        /// "IndexOfMaximum" Overload 3
        /// "IndexOfMaximum" returns the index of the largest double value found in the sublist of a  
        /// list of double values starting at index 'startIndex' and ending at index "endIndex".
        /// If the list is empty, -1 is returned.
        /// </summary>

        public static int IndexOfMaximum(List<double> l, int startIndex, int endIndex)
        {
            int indexOfMax = -1;

            if (l.Count > 0)
            {
                indexOfMax = startIndex;

                for (int i = startIndex + 1; i <= endIndex; i++)
                {
                    if (l[i] > l[indexOfMax])
                    {
                        indexOfMax = i;
                    }
                }
            }

            return indexOfMax;
        }

        /// <summary>
        /// 'QuickSelect' returns the kth smallest value in a list of double values. 
        /// The quickselect algorithm is similar to quicksort. This isn't a coincidence because  
        /// both algorithms were developed by Tony Hoare (aka C. A. R. Hoare) in the late 1950's.
        /// 'QuickSelect' is easy to implement recursively. To avoid recursion for the moment,
        /// it is implemented iteratively (i.e. with a loop).
        /// </summary>
        public static double QuickSelect(List<double> l, int k, int left, int right)
        {
            double kthSmallest = Double.NaN;

            if (l.Count > 0 && left >= 0 && left <= right && right < l.Count && k >= 1 && k <= l.Count)
            {
                int pivotIndex = -1;
                int kthSmallestIndex = k - 1;

                // Keep partitioning 'l' from 'left' to 'right' until the kth smallest value is the pivot.
                // This happens when pivotIndex = k – 1 because the pivot will be >= all items from index
                // 0 to index k-2. Therefore, k-1 items are <= pivot, making the pivot the kth smallest item.

                while (left < right && kthSmallestIndex != pivotIndex)
                {
                    // Reorganize 'l' in such a way that l = (Left Partition) + pivot + (Right Partition), where
                    // all items in (Left Partition) <= pivot and all items in (Right Partition) >= pivot.
                    pivotIndex = Sorting.LomutoPartition(l, left, right);

                    if (kthSmallestIndex < pivotIndex)
                    {
                        right = pivotIndex - 1; // kth smallest value is between left and pivotIndex-1
                    }
                    else if (kthSmallestIndex > pivotIndex)
                    {
                        left = pivotIndex + 1; // kth smallest value is between pivotIndex+1 and right
                    }
                }

                if (kthSmallestIndex == pivotIndex)
                {
                    kthSmallest = l[kthSmallestIndex];
                }
                else
                {
                    kthSmallest = l[left];
                }
            }

            return kthSmallest;
        }


        #endregion

        #region Rounding

        /// <summary>
        /// 'RoundOff' returns 'number' rounded off to 'decimalPlaces' places.
        /// There is a high risk of overflow with this method! No overflow checking
        /// has been included.
        /// </summary>

        public static double RoundOff(double number, int decimalPlaces)
        {
            double moveDecPtFactor = Math.Pow(10, decimalPlaces);
            double numDecPtMoved = number * moveDecPtFactor;
            double roundedDown = Math.Floor(numDecPtMoved);
            double roundedValue = Math.Floor(numDecPtMoved + 0.5d) / moveDecPtFactor;

            // Check whether "numDecPtMoved" ends in 0.5 and "roundedDown" is even
            // In this case, the returned value always needs to be rounded down.
            // e.g. 3.45 to 1 decimal place: 3.45 -> 34.5 -> 34 -> 3.4 (round to even rule)
            if (numDecPtMoved - roundedDown == 0.5d && roundedDown % 2 == 0)
            {
                roundedValue = Math.Floor(numDecPtMoved) / moveDecPtFactor;
            }

            return roundedValue;
        }

        #endregion

    }
}
