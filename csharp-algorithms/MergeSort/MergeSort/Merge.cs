using BenchmarkDotNet.Attributes;

namespace MergeSort
{
    public class Merge
    {
		public IEnumerable<object[]> ArrayData()
		{
			yield return new object[] { GenerateRandomNumber(200), 0, 199, "Small Unsorted" };
			yield return new object[] { GenerateRandomNumber(2000), 0, 1999, "Medium Unsorted" };
			yield return new object[] { GenerateRandomNumber(20000), 0, 19999, "Large Unsorted" };
			yield return new object[] { GenerateSortedNumber(200), 0, 199,"Small Sorted" };
			yield return new object[] { GenerateSortedNumber(2000), 0, 1999, "Medium Sorted" };
			yield return new object[] { GenerateSortedNumber(20000), 0, 19999, "Large Sorted" };
		}

		public void MergeArray(int[] array, int left, int middle, int right)
		{
			var leftArrayLength = middle - left + 1;
			var rightArrayLength = right - middle;
			var leftTempArray = new int[leftArrayLength];
			var rightTempArray = new int[rightArrayLength];
			int i, j;

			for (i = 0; i < leftArrayLength; ++i)
				leftTempArray[i] = array[left + i];
			for (j = 0; j < rightArrayLength; ++j)
				rightTempArray[j] = array[middle + 1 + j];

			i = 0;
			j = 0;
			int k = left;

			while (i < leftArrayLength && j < rightArrayLength)
			{
				if (leftTempArray[i] <= rightTempArray[j])
				{
					array[k++] = leftTempArray[i++];
				}
				else
				{
					array[k++] = rightTempArray[j++];
				}
			}

			while (i < leftArrayLength)
			{
				array[k++] = leftTempArray[i++];
			}

			while (j < rightArrayLength)
			{
				array[k++] = rightTempArray[j++];
			}
		}

		[ArgumentsSource(nameof(ArrayData))]
		[Benchmark]
		public int[] SortArray(int[] array, int left, int right, string arrayName)
		{
			if (left < right)
			{
				int middle = left + (right - left) / 2;

				SortArray(array, left, middle, arrayName);
				SortArray(array, middle + 1, right, arrayName);

				MergeArray(array, left, middle, right);
			}

			return array;
		}

		public static int[] GenerateRandomNumber(int size)
		{
			var array = new int[size];
			var rand = new Random();
			var maxNum = 10000;

			for (int i = 0; i < size; i++)
				array[i] = rand.Next(maxNum + 1);

			return array;
		}

		public static int[] GenerateSortedNumber(int size)
		{
			var array = new int[size];

			for (int i = 0; i < size; i++)
				array[i] = i;

			return array;
		}
	}
}

