namespace Master_of_Sorting_Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array length: ");
            int arrayLength = int.Parse(Console.ReadLine());

            Console.Write("Enter array min number: ");
            int minNumber = int.Parse(Console.ReadLine());

            Console.Write(@"Enter array max number: ");
            int maxNumber = int.Parse(Console.ReadLine());

            int[] array = GenerateRandomArray(arrayLength, minNumber, maxNumber);

            bool sorted = IsSorted(array);
            Console.WriteLine($"Is array sorted?: {sorted}");

            //BubbleSort(array);
            HybridSort(array);
        }

        static int[] GenerateRandomArray(int length, int min, int max)
        {
            Random random = new Random();
            int[] array = new int[length];

            for (int i = 0; i < length; i++)
            {
                array[i] = random.Next(min, max);
            }

            return array;
        }

        static bool IsSorted(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine($"Array: {string.Join(", ", array)}");
            Console.WriteLine();
        }

        static void BubbleSort(int[] array)
        {
            int n = array.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        (array[j + 1], array[j]) = (array[j], array[j + 1]);
                    }
                }
            }
            Console.WriteLine("Bubble Sort:");
            PrintArray(array);
        }

        static void HybridSort(int[] array)
        {
            if (array.Length <= 20)
            {
                Console.WriteLine("\tInsertion Sort");
                InsertionSort(array);
            }
            else
            {
                Console.WriteLine("\tMerge Sort");
                MergeSort(array,0, array.Length - 1);
            }

            PrintArray(array);
        }

        static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        static void MergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                MergeSort(array, left, mid);
                MergeSort(array, mid + 1, right);

                Merge(array, left, mid, right);
            }
        }

        static void Merge(int[] array, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArray = new int[n1];
            int[] rightArray = new int[n2];

            Array.Copy(array, left, leftArray, 0, n1);
            Array.Copy(array, mid + 1, rightArray, 0, n2);

            int i = 0, j = 0, k = left;

            while (i < n1 && j < n2)
            {
                if (leftArray[i] <= rightArray[j])
                {
                    array[k++] = leftArray[i++];
                }
                else
                {
                    array[k++] = rightArray[j++];
                }
            }

            while (i < n1)
            {
                array[k++] = leftArray[i++];
            }

            while (j < n2)
            {
                array[k++] = rightArray[j++];
            }
        }
    }
}
