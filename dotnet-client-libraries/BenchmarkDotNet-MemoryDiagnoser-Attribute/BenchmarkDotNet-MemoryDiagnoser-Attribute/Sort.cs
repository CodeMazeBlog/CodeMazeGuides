namespace BenchmarkDotNet_MemoryDiagnoser_Attribute
{
    public static class Sort
    {
        public static void QuickSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(arr, left, right);
                QuickSort(arr, left, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, right);
            }
        }

        public static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int middle = (left + right) / 2;
                MergeSort(arr, left, middle);
                MergeSort(arr, middle + 1, right);
                Merge(arr, left, middle, right);
            }
        }

        private static void Merge(int[] arr, int left, int middle, int right)
        {
            int[] temp = new int[right - left + 1];
            int i = left;
            int j = middle + 1;
            int k = 0;

            while (i <= middle && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                }
                k++;
            }

            while (i <= middle)
            {
                temp[k] = arr[i];
                i++;
                k++;
            }

            while (j <= right)
            {
                temp[k] = arr[j];
                j++;
                k++;
            }

            for (int x = 0; x < temp.Length; x++)
            {
                arr[left + x] = temp[x];
            }
        }

        private static int Partition(int[] arr, int left, int right)
        {
            int pivotValue = arr[right];
            int i = left - 1;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivotValue)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, right);
            return i + 1;
        }

        private static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
