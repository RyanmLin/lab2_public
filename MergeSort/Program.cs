using System;
using System.Threading;
using System.Diagnostics;

namespace MergeSort
{
    class Program
    {
        public static void Main(string[] args)
        {

            int ARRAY_SIZE = 1000;
            int[] arraySingleThread = new int[ARRAY_SIZE];
            var Rand = new Random();
            Stopwatch stopWatch = new Stopwatch();



            // TODO : Use the "Random" class in a for loop to initialize an array
            for (int i = 0; i < arraySingleThread.Length; i++)
            {
                arraySingleThread[i] = Rand.Next(0, 99999);
                //Console.WriteLine(arraySingleThread[i]);
            }

            // copy array by value.. You can also use array.copy()
            int[] arrayMultiThread = new int [arraySingleThread.Length];
            arraySingleThread.CopyTo(arrayMultiThread, 0);

            /*TODO : Use the  "Stopwatch" class to measure the duration of time that
               it takes to sort an array using one-thread merge sort and
               multi-thead merge sort
            */


            //TODO :start the stopwatch
            stopWatch.Start();
            //MergeSort(arraySingleThread, 0, arraySingleThread.Length-1);
            MultiThreadMergeSort(arrayMultiThread, 0, arrayMultiThread.Length - 1);
            //TODO :Stop the stopwatch
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string timeElapsed = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                                                ts.Hours, ts.Minutes, ts.Seconds,
                                                ts.Milliseconds / 10);
            Console.WriteLine("Single Thread time Elapsed: " + timeElapsed);
            //PrintArray(arraySingleThread);

            //TODO: Multi Threading Merge Sort







            
            // a helper function to print your array
            static void PrintArray(int[] myArray)
            {
                Console.Write("[");
                for (int i = 0; i < myArray.Length; i++)
                {
                    Console.WriteLine("{0} ", myArray[i]);

                }
                Console.Write("]");
                Console.WriteLine();

            }

            // a helper function to confirm your array is sorted
            // returns boolean True if the array is sorted
            static bool IsSorted(int[] a)
            {
                int j = a.Length - 1;
                if (j < 1) return true;
                int ai = a[0], i = 1;
                while (i <= j && ai <= (ai = a[i])) i++;
                return i > j;
            }

            // Multi Thread "Divide by 2"
            void MultiThreadMergeSort(int[] array, int left, int right)
            {
                Thread thread1 = new Thread(Program.yaya);
                thread1.Start(array, left, right);

                /*Thread thread2 = new Thread(Program.yaya);
                thread2.Start();

                Thread thread3 = new Thread(Program.yaya);
                thread3.Start();
                // TODO :implement
                if (left < right)
                {
                    int mid = left + (right - left) / 2;

                    
                    //MergeSort(array, left, mid);
                    //Thread thread2 = new Thread(MultiThreadMergeSort(array, mid + 1, right));
                    //thread2.Start();
                    //MergeSort(array, mid + 1, right);

                    //Merge(array, left, mid, right);
                }*/
            }
            /*
            void MultiThreadMergeSort(int[] arr)
            {

            }

            void DivideIntoSubarrays(int[] arr, int num)
            {
                // Divide array into num subarrays
                // Put each subarray into a different thread
                for(int i = 1; i <= num; i++)
                {
                    // MultiThread Merge Sort for thread i
                }
            }
            */
        }
        //public static void yaya(int[] array, int left, int right)
        public static void yaya(Object arrayO, Object leftO, Object rightO)
        {
            int[] array;
            int left;
            int right;
            try
            {
                array = (int[])arrayO;
                left = (int)leftO;
                right = (int)rightO;
            }
            catch (InvalidCastException)
            {
                return;
            }

            // TODO :implement
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                yaya(array, left, mid);
                yaya(array, mid + 1, right);

                //Merge(array, left, mid, right);
                // TODO :implement
                // variables for looping
                int i, j, k = 0;
                int l = mid - left + 1;
                int m = right - mid;

                // create temporary arrays
                int[] Left = new int[l];
                int[] Right = new int[m];

                // Copy left half to left array and
                // right half to right array
                for (i = 0; i < l; i++) Left[i] = array[left + i];
                for (j = 0; j < m; j++) Right[j] = array[mid + 1 + j];

                // Merge the temporary Arrays Together
                i = 0;
                j = 0;
                k = left;// initial index of merged subarray array

                while (i < l && j < m)
                {
                    if (Left[i] <= Right[j])
                    {
                        array[k] = Left[i];
                        i++;
                    }
                    else
                    {
                        array[k] = Right[j];
                        j++;
                    }
                    k++;
                }

                // copy the rest of the elements in Left[]
                while (i < l)
                {
                    array[k] = Left[i];
                    i++;
                    k++;
                }

                while (j < m)
                {
                    array[k] = Right[j];
                    j++;
                    k++;
                }
            }

            Console.WriteLine("yaya accessed");
            Thread.Sleep(4000);
            Console.WriteLine("yaya fin");
        }

        /*********************** Methods **********************
             *****************************************************/
        /*
        implement Merge method. This method takes two sorted array and
        and constructs a sorted array in the size of combined arrays
        */

        void Merge(int[] array, int left, int mid, int right)
        {

            // TODO :implement
            // variables for looping
            int i, j, k = 0;
            int l = mid - left + 1;
            int m = right - mid;

            // create temporary arrays
            int[] Left = new int[l];
            int[] Right = new int[m];

            // Copy left half to left array and
            // right half to right array
            for (i = 0; i < l; i++) Left[i] = array[left + i];
            for (j = 0; j < m; j++) Right[j] = array[mid + 1 + j];

            // Merge the temporary Arrays Together
            i = 0;
            j = 0;
            k = left;// initial index of merged subarray array

            while (i < l && j < m)
            {
                if (Left[i] <= Right[j])
                {
                    array[k] = Left[i];
                    i++;
                }
                else
                {
                    array[k] = Right[j];
                    j++;
                }
                k++;
            }

            // copy the rest of the elements in Left[]
            while (i < l)
            {
                array[k] = Left[i];
                i++;
                k++;
            }

            while (j < m)
            {
                array[k] = Right[j];
                j++;
                k++;
            }
        }


        /*
        implement MergeSort method: takes an integer array by reference
        and makes some recursive calls to intself and then sorts the array
        */
        void MergeSort(int[] array, int left, int right)
        {
            // TODO :implement
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);

                Merge(array, left, mid, right);
            }
        }


    }
}
