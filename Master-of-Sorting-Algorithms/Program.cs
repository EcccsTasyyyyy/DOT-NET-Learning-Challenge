using System.Diagnostics;

namespace Master_of_Sorting_Algorithms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ShowMenu();
        }

        static int[] GenerateRandomArray()
        {
            Console.WriteLine("Enter array parameters: ");
            Console.Write("Enter array length: ");
            int length = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter array min number: ");
            int min = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter array max number: ");
            int max = int.Parse(Console.ReadLine() ?? "0");

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
                if (array[i] > array[i + 1]) return false;
            }
            return true;
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine("Array: " + string.Join(", ", array));
        }

        static void RecursiveBubbleSort(int[] array, int n)
        {
            if (n == 1) return;

            for (int i = 0; i < n - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                }
            }

            RecursiveBubbleSort(array, n - 1);
        }

        static void HybridSort(int[] array)
        {
            if (array.Length <= 1000)
            {
                Console.WriteLine("Using Insertion Sort for small arrays");
                InsertionSort(array);
            }
            else
            {
                Console.WriteLine("Using Merge Sort for large arrays");
                MergeSort(array, 0, array.Length - 1);
            }
        }

        static void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
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

            while (i < n1) array[k++] = leftArray[i++];
            while (j < n2) array[k++] = rightArray[j++];
        }

        static void CompareAlgorithms(int[] array)
        {
            int[] bubbleArray = (int[])array.Clone();
            int[] insertionArray = (int[])array.Clone();
            int[] mergeArray = (int[])array.Clone();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            RecursiveBubbleSort(bubbleArray, bubbleArray.Length);
            sw.Stop();
            Console.WriteLine($"Bubble Sort time: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            InsertionSort(insertionArray);
            sw.Stop();
            Console.WriteLine($"Insertion Sort time: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            MergeSort(mergeArray, 0, mergeArray.Length - 1);
            sw.Stop();
            Console.WriteLine($"Merge Sort time: {sw.ElapsedMilliseconds} ms");

            Console.WriteLine($"Bubble Sort correct: {IsSorted(bubbleArray)}");
            Console.WriteLine($"Insertion Sort correct: {IsSorted(insertionArray)}");
            Console.WriteLine($"Merge Sort correct: {IsSorted(mergeArray)}");
        }

        static void ShowMenu()
        {
            int[]? array = null;

            while (true)
            {
                Console.WriteLine("\nChoose an option: ");
                Console.WriteLine("1 - Generate random array");
                Console.WriteLine("2 - Apply a sorting algorithm");
                Console.WriteLine("3 - Compare all algorithms");
                Console.WriteLine("0 - Exit");

                int userInput = int.Parse(Console.ReadLine() ?? "0");

                switch (userInput)
                {
                    case 1:
                        array = GenerateRandomArray();
                        PrintArray(array);
                        break;
                    case 2:
                        if (array == null)
                        {
                            Console.WriteLine("You need to generate an array first.");
                        }
                        else
                        {
                            Console.WriteLine("Choose sorting algorithm:");
                            Console.WriteLine("1 - Bubble Sort");
                            Console.WriteLine("2 - Insertion Sort");
                            Console.WriteLine("3 - Merge Sort");
                            Console.WriteLine("4 - Hybrid Sort");

                            int sortChoice = int.Parse(Console.ReadLine() ?? "0");

                            switch (sortChoice)
                            {
                                case 1:
                                    RecursiveBubbleSort(array, array.Length);
                                    break;
                                case 2:
                                    InsertionSort(array);
                                    break;
                                case 3:
                                    MergeSort(array, 0, array.Length - 1);
                                    break;
                                case 4:
                                    HybridSort(array);
                                    break;
                                default:
                                    Console.WriteLine("Invalid option.");
                                    break;
                            }
                            PrintArray(array);
                        }
                        break;
                    case 3:
                        if (array == null)
                        {
                            Console.WriteLine("You need to generate an array first.");
                        }
                        else
                        {
                            CompareAlgorithms(array);
                        }
                        break;
                    case 0:
                        Console.WriteLine("Exiting program.");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }
    }
}
