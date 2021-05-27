using System;
using System.Collections.Generic;

namespace MathematicalFunctionsSearchingSorting
{
    #region Notes on Object-Oriented Programming
    /*
     * OBJECT-ORIENTED PROGRAMMING (OOP)
     * 
     * CLASSES and OBJECTS: Classes are "templates" or "blueprints" for "making" objects. They ENCAPSULATE 
     * (see below) data and the methods (procedures) that operate on the data. When a class is used to 
     * "make" an object, the object is called an "instance" of the class.
     * 
     * Analogy: Class = Cookie Cutter    Object/Instance of the Class = Cookie
     * 
     * Objects often represent tangible things like buttons or text boxes but they can also represent more
     * abstract entities such as geometric shapes. Classes contain both DATA MEMBERS and FUNCTION MEMBERS.
     * 
     * 1. DATA MEMBERS -> Variables or objects that belong to a class or an instance of the class
     * 
     *    (a) Data members store information about the STATE of an object.
     *    
     *    (b) In C#, the data members are called FIELDS. In Java, the data members are called DATA FIELDS.
     *        
     *    (b) Because of the OOP principle of ABSTRACTION (see below), fields in C# are usually declared as
     *        "private." Abstraction is achieved when each object keeps its state private. Other objects 
     *        don’t have direct access to this state. Instead, they can only access the data members that  
     *        are EXPOSED to other objects.
     *                
     *        C# -> Fields can be exposed to other objects through PROPERTIES. (e.g. "Text" property)
     *        Java -> Data fields are exposed to other objects only through calls of public methods
     *                called "getters" and "setters." (e.g. getText(), setText())
     *                
     * 2. PROCEDURE/FUNCTION MEMBERS -> Procedures/functions that belong to a class or an instance of the class
     *    
     *    (a) Procedure/function members are used to INQUIRE ABOUT or CHANGE THE STATE of an object.
     *    
     *    (b) Across most object-oriented languages, such procedures/functions are called METHODS.
     *    
     *    (c) Methods can be OVERLOADED. This means that multiple methods can have the same name as 
     *        long as their parameters differ in either number or type.
     * 
     * 3. CONSTRUCTOR METHODS (CONSTRUCTORS) -> Special methods that are called to initialize a newly
     *    created object. The name of a constructor method is always the same as the name of the class.
     *    
     * 4. INNER CLASSES -> Classes can be defined WITHIN classes.
     *                                          
     * The four basic principles of OOP are ENCAPSULATION, ABSTRACTION, INHERITANCE, and POLYMORPHISM.
     * 
     * ENCAPSULATION
     * Encapsulation means that data, and the methods that operate on the data, are BUNDLED within a single unit.
     * e.g. a class bundles data in the form of variables and objects (called "fields" collectively in C#
     * and "data fields" in Java) with the methods that operate on these variables and objects.
     *                     
     * ABSTRACTION
     * Reduce complexity by hiding details from the user (of a class for example). Users only need to know
     * which methods are available and how to call them. The implementation of the methods is HIDDEN!
     *              
     * INHERITANCE
     * New classes/structures can be built from existing classes/structures. When a class is built upon an
     * existing class, it inherits all its members. For example, the class "MathematicalFunctionsSortingForm"
     * is built upon the existing .NET class called "Form". "MathematicalFunctionsSortingForm" INHERITS
     * all members of the "Form" class and also has members of its own. "MathematicalFunctionsSortingForm"
     * is called the SUBCLASS and "Form" is called the SUPERCLASS.
     *              
     * POLYMORPHISM
     * From Greek: Poly = many, Morph = change or form
     * In OOP, "polymorphism" refers to the ability to present the SAME INTERFACE for DIFFERENT UNDERLYING
     * FORMS (e.g. data types).
     * e.g. The mathematical operators +, -, *, / and % work with ANY numeric data type. The data types can
     *      be different (e.g. int and double) but the interface for working with them (in this case the 
     *      operators) is the same.
     * e.g. Create a class (superclass) called "Shape" that serves as the foundation for subclasses such
     *      as "Square", "Circle", "Polygon", etc. Although each shape is diffrent in some way, the "Draw" 
     *      operation is the same. Each subclass implements its own "Draw" method because the details of
     *      drawing differ from one shape to another but the NAME of the method is the same!
     */


    #endregion

    #region Purpose of this Class
    /*
    * The 'Sorting' class is being used only as a storage place for sorting methods. It is not intended to be
    * used as a template for making objects. In fact, it CANNOT be used as such because it does not contain
    * any constructor methods (done intentionally). Recall that constructor methods are called to initialize
    * objects. Since this class cannot be used to create objects, there is no need for any constructors.
    */
    #endregion

    public static class Sorting
    {
        // Constructor has been removed because of reasons specified in the last comment.
        //public Sort()
        //{
        //}

        #region Explanation of Time Complexity

        /**************************************************************************************************
         * 
         * The "time complexity" (sometimes also known informally as "running time") of an algorithm is a 
         * measure of "how fast" it is. For comparison-based sorting algorithms, time complexity generally 
         * refers to the number of comparisons required to sort a list/array containing n items. In general, 
         * it is extremely difficult to determine the exact number of comparisons needed to sort lists 
         * because this depends largely on the initial ordering of the data and other complicating factors. 
         *  
         * Because of this, computer scientists prefer to specify upper bounds on the number of comparisons
         * required. Most of the sorting algorithms that we have studied have an average time complexity
         * denoted by O(n^2). This is read "order n squared" and it means that to sort n items, no more
         * than an^2 + bn + c comparisons are required, where a, b and c are constants that differ from
         * one algorithm to another. That is, the number of comparisons is no greater than some quadratic
         * function of n.
         * 
         * The fastest comparison-based sorting algorithms have an average time complexity of O(nlogn). 
         * Even for such algorithms, worst-case performance can still be O(n^2).
         * 
         * See https://en.wikipedia.org/wiki/Sorting_algorithm#Comparison_of_algorithms for a detailed
         * comparison of the best-, worst- and average-case time complexity of a wide variety of different
         * sorting algorithms. This source also gives information on space complexity (memory requirements)
         * and stability (see next comment).
         * 
         **************************************************************************************************/
        #endregion

        #region General Comments on Sorting Algorithms

        /*
         * General Comments about the Sorting Algorithms Implemented Below
         *
         * The implementations have some desirable features.
         * 
         * 1. They are all "IN-PLACE" implementations, which means that the data are sorted entirely within the  
         *    given lists. No additional lists or arrays are used, which makes the most efficient use of memory.
         * 2. They do not return sorted lists, because this would also require additional memory. Instead, they  
         *    directly alter the lists passed to them. This happens because 'List<>' is a reference type.
         * 
         *    e.g. Sort.SelectionSort(numberList); 
         *
         *         A REFERENCE to 'numberList is passed to 'l' (i.e. the method is told where in RAM 
         *         "numberList's" data are located). Within 'SelectionSort' then, the name 'l' is just a 
         *         temporary "renaming" of 'numberList', that is, an alias for 'numberList'. Consequently, 
         *         any change made to 'l' is actually a change to 'numberList'.
         * 
         * STABLE versus UNSTABLE Sorting Algorithms
         * Stable sorting algorithms ALWAYS preserve the initial order of identical items/elements (i.e. the 
         * order of identical items/elements in the input). Unstable sorting algorithms, on the other hand, do
         * not always preserve this order. This isn't important at all when sorting records that contain only
         * one field. However, it is very important when records contain multiple fields. In the latter case,
         * stable sorts always preserve the initial order of records with identical keys.
         *   
         * e.g. Record: | lastName | firstName | address | telephone number | 
         *      Suppose that the key is 'lastName'. Stable sorts will maintain the initial order of the records 
         *      by 'lastName.' Unstable sorts don't necessarily preserve this order. 
         *      See https://en.wikipedia.org/wiki/Sorting_algorithm#Stability for more information.
         */

        #endregion

        #region Sorting Methods
        /// <summary>
        /// 'SelectionSort' uses the selection sort algorithm to sort the given list of double values in 
        /// ascending order. The average time complexity of selection sort is O(n^2) comparisons.
        /// Selection sort is UNSTABLE.
        /// </summary>
        public static void SelectionSort(List<double> l)
        {
            for (int i = 0; i < l.Count; i++)
            {
                //Find index of smallest value from index "i" to index "l.Count-1"
                int minIndex = i;

                for (int j = i + 1; j < l.Count; j++)
                {
                    if (l[j] < l[minIndex])
                    {
                        minIndex = j;
                    }
                }

                //Swap item "i" with item "minIndex"
                double copy = l[i];
                l[i] = l[minIndex];
                l[minIndex] = copy;
            }
        }

        /// <summary>
        /// 'BubbleSort' uses the bubble sort algorithm to sort the given list of double values in 
        /// ascending order. The average time complexity of bubble sort is O(n^2) comparisons.
        /// Bubble sort is STABLE.
        /// </summary>

        public static void BubbleSort(List<double> l)
        {
            for (int i = 1; i < l.Count; i++)
            {
                bool sorted = true;
                for (int j = 1; j <= l.Count - i; j++)
                {
                    if (l[j - 1] > l[j])
                    {
                        //Swap items "j-1" and "j"
                        double copy = l[j - 1];
                        l[j - 1] = l[j];
                        l[j] = copy;

                        //Since a swap took place, can't confirm that list is sorted yet.
                        sorted = false;
                    }
                }

                // If no swaps took place in the pass that was just completed, the list is sorted.
                if (sorted)
                {
                    break; //Exit loop because list is already sorted.
                }
            }
        }

        /// <summary>
        /// 'CocktailSort' uses the cocktail sort algorithm to sort the given list of double values in 
        /// ascending order. The average time complexity of cocktail sort is O(n^2) comparisons.
        /// Cocktail sort is STABLE.
        /// </summary>

        public static void CocktailSort(List<double> l)
        {
            bool sorted = false;
            int start = 0;
            int end = l.Count - 1;

            while (!sorted)
            {
                sorted = true;

                //Forward pass from index 'start' to index 'i-1'
                for (int i = start; i < end; i++)
                {
                    if (l[i] > l[i + 1])
                    {
                        //Swap items "i" and "i+1"
                        double copy = l[i];
                        l[i] = l[i + 1];
                        l[i + 1] = copy;

                        //Since a swap took place, can't confirm that list is sorted yet.
                        sorted = false;
                    }
                }

                // If no swaps took place in the pass that was just completed, the list is sorted.
                if (sorted)
                {
                    break; //Exit loop because list is already sorted.
                }

                end--;

                //Backward pass from index 'end-1' to 'start'
                for (int i = end - 1; i >= start; i--)
                {
                    if (l[i] > l[i + 1])
                    {
                        //Swap items "i" and "i+1"
                        double copy = l[i];
                        l[i] = l[i + 1];
                        l[i + 1] = copy;

                        //Since a swap took place, can't confirm that list is sorted yet.
                        sorted = false;
                    }
                }
            }
        }

        /// <summary>
        /// 'InsertionSort' uses the insertion sort algorithm to sort the given list of double values in 
        /// ascending order. The average time complexity of insertion sort is O(n^2) comparisons.
        /// Insertion sort is STABLE.
        /// </summary>

        public static void InsertionSort(List<double> l)
        {
            for (int i = 1; i < l.Count; i++)
            {
                double valueToInsert = l[i];
                int j = i;

                // Search for insertion point while shifting values one place to the right
                while (j >= 1 && l[j - 1] > valueToInsert)
                {
                    l[j] = l[j - 1];
                    j--;
                }

                // Insert saved value where it belongs 
                l[j] = valueToInsert;
            }
        }

        // Shell sort is a generalization of insertion sort.
        // This implementation uses a quadruple-nested looping structure. It's possible to use a triple-
        // nested looping structure but the logic is a little more difficult to comprehend.
        // Outermost Loop: Controls the value of h
        // Next Loop: Allows h-sorting to be performed for sublists starting at indices 0, 1, ..., h - 1
        // Next Loop: h-sorts sublist beginning at index 'start' using insertion sort
        // Innermost Loop: Shifts items h places to the right to make room for item to be inserted

        /// <summary>
        /// 'ShellSort' uses the Shell sort algorithm to sort the given list of double values in ascending
        /// order. The time complexity of Shell sort depends a great deal on the sequence of gap sizes
        /// (h-values) used. It's very difficult to determine the average time complexity of Shell sort
        /// but it's conjectured to be O(n^(5/4))=O(n^1.25) comparisons (much better than quadratic). 
        /// Shell sort is UNSTABLE.
        /// </summary>
        public static void ShellSort(List<double> l)
        {
            int n = l.Count;
            int h = n / 2; // h = gap size

            // h-sort the list starting with h = n/2, then cut h in half after each repetition until h = 0.
            // This was the sequence of gap sizes proposed by Donald Shell in 1959 when he invented Shell sort.
            // Since then, many other sequences of gap sizes have been studied. See 
            // https://en.wikipedia.org/wiki/Shellsort#Gap_sequences for more information.

            while (h >= 1)
            {
                // h-sort the list for current value of h
                for (int start = 0; start < h; start++)
                {
                    // Use insertion sort to sort the sublist consisting of items start, start + h, start + 2h, ... ,
                    // start + mh, where m is the largest whole number such that start + mh < n.
                    for (int i = start + h; i < n; i += h)
                    {
                        double valueToInsert = l[i];
                        int j = i;

                        // Make room for insertion by shifting values h places to the right.
                        while (j >= h && l[j - h] > valueToInsert)
                        {
                            l[j] = l[j - h];
                            j -= h;
                        }

                        l[j] = valueToInsert; // Insert saved value where it belongs.
                    }
                }

                h /= 2; // Go on to the next value of 'h'
            }
        }

        // The following method is an implementation of the quick sort algorithm.
        //
        // Description of Quick Sort Algorithm:
        // The first step is to divide the sublist of 'l' that runs from index 'leftmost' to index 'rightmost',
        // inclusive, into two parts about a "pivot" value. The pivot can be chosen in a variety of ways. This 
        // implementation uses the "middle" item of this sublist. (See comments below.) After partitioning is
        // completed, this sublist takes the following form: (Left Partition) + Pivot + (Right Partition), where
        // (Left Partition) consists of all items <= pivot and (Right Partition) consists of all items >= pivot.

        /// <summary>
        /// 'QuickSort' uses the quick sort algorithm to sort the given list of double values in ascending order.
        /// The average time complexity of quick sort is O(nlogn) comparisons. The worst-case performance of 
        /// QuickSort is still O(n^2) comparisons. QuickSort is UNSTABLE (although there are stable variants).
        /// </summary>
        public static void QuickSort(List<double> l, int leftmost, int rightmost)
        {
            // Partition the sublist from index 'leftmost' to index 'rightmost' as described above. It is 
            // perfectly acceptable to call the 'LomutoPartition' method here instead of specifying the
            // entire code for partitioning. However, doing so would slightly decrease the efficiency of the
            // 'QuickSort' method because of the increased overhead required for method calls.
            // The Lomuto partition algorithm is used because it's simpler and more efficient than the naive 
            // algorithm originally used and somewhat easier to understand than Hoare partition.

            if (leftmost < rightmost && leftmost >= 0 && rightmost < l.Count)
            {
                int pivotIndex = leftmost + (rightmost - leftmost) / 2; // Immune from overflow exception
                double pivot = l[pivotIndex];

                // Move pivot to the right end by swapping:
                l[pivotIndex] = l[rightmost];
                l[rightmost] = pivot;

                // Assume at first that the pivot's final resting place is at index 'leftmost'
                pivotIndex = leftmost;

                // Each time a value smaller than the 'pivot' is found, exchange it with 
                // l[pivotIndex] and increase 'pivotIndex' by 1.
                for (int i = leftmost; i < rightmost; i++)
                {
                    if (l[i] <= pivot)
                    {
                        double copy = l[pivotIndex];
                        l[pivotIndex] = l[i];
                        l[i] = copy;
                        pivotIndex++;
                    }
                }

                // Move the pivot to its final resting place by swapping 
                l[rightmost] = l[pivotIndex];
                l[pivotIndex] = pivot;

                // Now perform quick sort on the left and right partitions
                QuickSort(l, leftmost, pivotIndex - 1);
                QuickSort(l, pivotIndex + 1, rightmost);

                // Note that Hoare's partitioning scheme does not necessarily place the pivot in its final resting place.
                // Because of this, the recursive calls need to be slightly different:
                // QuickSort(l, leftmost, pivotIndex);
                // QuickSort(l, pivotIndex + 1, rightmost);
                // Details are provided in the comment that precedes the 'HoarePartition' method.
            }
        }
        #endregion

        #region Partitioning Methods

        /// <summary>
        /// 'NaivePartition' divides the sublist of 'l' that runs from index 'leftmost' to index 'rightmost', inclusive, 
        /// into two parts about a "pivot" value. The pivot can be chosen in a variety of ways.  After partitioning is
        /// completed, this sublist takes the following form: (Left Partition) + Pivot + (Right Partition), where
        /// (Left Partition) consists of all items <= pivot and (Right Partition) consists of all items >= pivot.
        /// 
        /// This partitioning method is the first thing that occurred to me when I did my best to forget what I already
        /// knew about 'QuickSort'. Upon reflection, I realized that in spite of the simplicity of my algorithm, 
        /// it turned out to be very inefficient. Better algorithms, Lomuto partition and Hoare partition, are
        /// given below. The average time complexity of both algorithms is O(n) comparisons, although the Hoare method 
        /// can be shown to be the more efficient of the two. 
        /// 
        /// Unfortunately, it turns out that my naive algorithm's time complexity is O(n^2) comparisons, which 
        /// completely nullifies the speed advantages of QuickSort.
        /// </summary>

        // The pivot can be chosen in a variety of ways. For the sake of simplicity, all the methods below 
        // use the "middle" item of the sublist running from 'leftmost' to 'rightmost'. This turns out to be a 
        // good choice to prevent worst-case performance caused by applying 'QuickSort' to a list that's
        // already sorted. Even better choices are possible.
        // See https://en.wikipedia.org/wiki/Quicksort#Choice_of_pivot for details.

        public static int NaivePartition(List<double> l, int leftmost, int rightmost)
        {
            int pivotIndex = -1;

            // Partition the sublist from index 'leftmost' to index 'rightmost' as described above.

            if (leftmost < rightmost && leftmost >= 0 && rightmost < l.Count)
            {
                pivotIndex = (leftmost + rightmost) / 2; // This could cause an overflow exception
                int smallerThanPivot = -1; // Don't count pivot itself
                double pivot = l[pivotIndex];

                // Count how many values are smaller than or equal to the pivot
                // Requires 'leftmost - rightmost + 1' comparisons (i.e. 'n' comparisons)
                for (int i = leftmost; i <= rightmost; i++)
                {
                    if (l[i] <= pivot)
                    {
                        smallerThanPivot++;
                    }
                }

                // Move the pivot to its final resting place by swapping
                int originalPivotIndex = pivotIndex;
                pivotIndex = leftmost + smallerThanPivot;
                l[originalPivotIndex] = l[pivotIndex];
                l[pivotIndex] = pivot;

                // Now partition the list about pivot (which is found at index 'pivotIndex')
                // Outer loop requires 'pivotIndex - leftmost' comparisons (i.e. n/2 comparsions on average)
                for (int i = leftmost; i < pivotIndex; i++)
                {
                    if (l[i] > pivot)
                    {
                        //Find a value in the right partition that is smaller than pivot.
                        int j = pivotIndex + 1;

                        // This loop requires up to 'rightmost - pivot' comparisons. On average, 
                        // it requires '(rightmost - pivot)/2' comparisons (i.e. n/2 comparsions on average).
                        while (l[j] > pivot)
                        {
                            j++;
                        }

                        //Then exchange it with l[i].
                        double copy = l[j];
                        l[j] = l[i];
                        l[i] = copy;
                    }
                }
            }

            return pivotIndex;
        }

        /// <summary>
        /// 'LomutoPartition' divides the sublist of 'l' that runs from index 'leftmost' to index 'rightmost', inclusive, 
        /// into two parts about a "pivot" value. After partitioning is completed,
        /// this sublist takes the following form: (Left Partition) + Pivot + (Right Partition), where
        /// (Left Partition) consists of all items <= pivot and (Right Partition) consists of all items >= pivot.
        /// 
        /// The Lomuto partition algorithm, attributed to Nico Lomuto, is simpler and faster than the naive algorithm
        /// used above. Unlike the above algorithm, it requires only one pass of the data. 
        /// The average time complexity of the Lomuto scheme is O(n) comparisons.
        /// </summary>
        public static int LomutoPartition(List<double> l, int leftmost, int rightmost)
        {
            int pivotIndex = -1;

            // Partition the sublist from index 'leftmost' to index 'rightmost' as described above.

            if (leftmost < rightmost && leftmost >= 0 && rightmost < l.Count)
            {
                pivotIndex = leftmost + (rightmost - leftmost) / 2; // Immune from overflow exception
                double pivot = l[pivotIndex];

                // Move pivot to the (right) end by swapping.
                l[pivotIndex] = l[rightmost];
                l[rightmost] = pivot;

                // Assume at first that the pivot's final resting place is at index 'leftmost'
                pivotIndex = leftmost;

                // Each time a value smaller than the 'pivot' is found, exchange it with 
                // l[pivotIndex] and increase 'pivotIndex' by 1.
                for (int i = leftmost; i < rightmost; i++)
                {
                    if (l[i] <= pivot)
                    {
                        double copy = l[pivotIndex];
                        l[pivotIndex] = l[i];
                        l[i] = copy;
                        pivotIndex++;
                    }
                }

                // Move the pivot to its final resting place by swapping 
                l[rightmost] = l[pivotIndex];
                l[pivotIndex] = pivot;
            }

            return pivotIndex;
        }

        /// <summary>
        /// ****NOTE: The Hoare partitioning scheme is a little different from the previous two.****
        /// 'HoarePartition' divides the sublist of 'l' that runs from index 'leftmost' to index 'rightmost', inclusive, 
        /// into two parts called the 'Left Partition' and the 'Right Partition'. After partitioning is completed,
        /// this sublist takes the following form: (Left Partition) + (Right Partition), where each item in
        /// (Left Partition) is <= each item in (Right Partition).
        /// 
        /// The Hoare partition algorithm was introduced by C. A. R. Hoare (aka Tony Hoare), the inventor 
        /// of quick sort. It is even more efficient than the Lomuto method BUT is somewhat more difficult 
        /// to understand and implement. It uses two variables, 'i' and 'pivotIndex', to store index values   
        /// that are initially at opposite ends of the list. The values of these two variables "move" toward   
        /// each other, 'i' increasing by one whenever 'l[i]' < 'pivot' and 'pivotIndex' decreasing by one 
        /// whenever 'l[pivotIndex]' > 'pivot'. When values 'l[pivotIndex]' and 'l[i]' are found to be in the  
        /// wrong order relative to the pivot, they are swapped. This continues as long as 'i' < 'pivotIndex'.
        /// 
        /// ****VERY IMPORTANT NOTE!****
        /// The Hoare partitioning scheme does NOT necessarily return the index of the final resting place of the 
        /// pivot! It only guarantees that the all items with indices <= 'pivotIndex' are smaller than all items
        /// with indices > 'pivotIndex'.
        /// 
        /// The average time complexity of the Hoare partitioning scheme is O(n) comparisons.
        /// </summary>
        public static int HoarePartition(List<double> l, int leftmost, int rightmost)
        {
            // Partition the sublist from index 'leftmost' to index 'righmost' as described above.
            int pivotIndex = -1;

            if (leftmost < rightmost && leftmost >= 0 && rightmost < l.Count)
            {
                double pivot = l[leftmost + (rightmost - leftmost) / 2]; // Immune from overflow exception
                int i = leftmost - 1;
                pivotIndex = rightmost + 1;

                while (i < pivotIndex)
                {
                    // Starting from the left, loop until a value is found that is >= pivot
                    do
                    {
                        i++;
                    } while (l[i] < pivot);

                    // Starting from the right, loop until a value is found that is <= pivot
                    do
                    {
                        pivotIndex--;
                    } while (l[pivotIndex] > pivot);

                    if (i < pivotIndex)
                    {
                        // Swap l[i] with l[pivotIndex] because they are out of order relative to 'pivot'
                        double copy = l[i];
                        l[i] = l[pivotIndex];
                        l[pivotIndex] = copy;
                    }
                }
            }

            return pivotIndex;
        }

        #endregion

        #region Scrambling (Shuffling)

        /// <summary>
        /// Return a scrambled (shuffled) version of listOfNumbers.
        /// </summary>
        public static void Scramble(List<double> l)
        {
            // Create a 'Random' object
            Random randomNumberGenerator = new Random();

            for (int i = 0; i < l.Count; i++)
            {
                int randomIndex = randomNumberGenerator.Next(0, l.Count);

                // Swap item 'i' with item 'randomIndex'
                double copy = l[i];
                l[i] = l[randomIndex];
                l[randomIndex] = copy;
            }

        }

        #endregion
    }
}