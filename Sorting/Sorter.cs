using System;

namespace Sorting
{
    public class Sorter
    {
        public readonly string[] unsortedArray;

        public long CountOperation { get; set; }

        public Sorter(string[] unsortedArray)
        {
            this.unsortedArray = unsortedArray;
        }
        
        public long Sorted()
        {
            MergeSort(unsortedArray, 0, unsortedArray.Length - 1);
            var result = CountOperation;
            CountOperation = 0;
            return result;
        }
        
        private void Merge(string[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new string[highIndex - lowIndex + 1];
            var index = 0;
            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (string.Compare(array[left], array[right], StringComparison.Ordinal) <  0)
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
                CountOperation += 3;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
                CountOperation += 2;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
                CountOperation += 2;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
                CountOperation += 1;
            }
        }

        private void MergeSort(string[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }
        }

        public void PrintArray()
        {
            foreach (var item in unsortedArray)
            {
                Console.WriteLine(item);
            }
        }
    }
}