int[] nums = { 2, 2, 7, 8, 1 };
Console.WriteLine("Ввод:\t" + string.Join("\t", nums));
int[] result = QuickSortNums(nums, 0, nums.Length - 1);
Console.WriteLine("Вывод:\t" + string.Join("\t", result));


int[] QuickSortNums(int[] array, int minIndex, int maxIndex)
{
    if (minIndex >= maxIndex)
    {
        return array;
    }

    var midIndex = SplitToLowAndHighFindMidElement(array, minIndex, maxIndex);
    QuickSortNums(array, minIndex, midIndex - 1);
    QuickSortNums(array, midIndex + 1, maxIndex);

    return array;
}

int SplitToLowAndHighFindMidElement(int[] array, int minIndex, int maxIndex)
{
    int midindex = minIndex - 1;
    for (int index = minIndex; index < maxIndex; index++)
    {
        if (array[index] < array[maxIndex])
        {
            midindex++;
            SwapPlaces(ref array[midindex], ref array[index]);
        }
    }
    midindex++;
    SwapPlaces(ref array[midindex], ref array[maxIndex]);
    return midindex;
}

void SwapPlaces(ref int num1, ref int num2)
{
    var temp = num1;
    num1 = num2;
    num2 = temp;
}