//Быстрая сортировка

Console.WriteLine("Quick sort nums massive");
int[] nums = { 2, 2, 7, 8, 1 };
Console.WriteLine("Ввод nums:\n" + string.Join("\t", nums));
QuickSortGroup(nums);
Console.WriteLine("Вывод nums по возрастанию:\n" + string.Join("\t", nums));
QuickSortGroup(nums, true);
Console.WriteLine("Вывод nums по убыванию:\n" + string.Join("\t", nums));

//Сортировка выбором

Console.WriteLine("\nSelection sort nums2 massive");
int[] nums2 = { 2, 10, 9, 9, 1, 3 };
Console.WriteLine("Ввод nums2:\n" + string.Join("\t", nums2));
SelectionSortGroup(nums2);
Console.WriteLine("Вывод nums2 по возрастанию:\n" + string.Join("\t", nums2));
SelectionSortGroup(nums2, true);
Console.WriteLine("Вывод nums2 по убыванию:\n" + string.Join("\t", nums2)); 
Console.ReadLine(); 

#region Quick Sort

void QuickSortGroup(int[] nums, bool checkdescending = false)
{
    nums = InsideQuickSort(nums, 0, nums.Length - 1, checkdescending);
}

int[] InsideQuickSort(int[] array, int minIndex, int maxIndex, bool checkdescending)
{
    if (minIndex >= maxIndex)
    {
        return array;
    }

    var midIndex = SplitToLowAndHighFindMidElement(array, minIndex, maxIndex, checkdescending);
    InsideQuickSort(array, minIndex, midIndex - 1, checkdescending);
    InsideQuickSort(array, midIndex + 1, maxIndex, checkdescending);

    return array;
}

int SplitToLowAndHighFindMidElement(int[] array, int minIndex, int maxIndex, bool checkdescending)
{
    int midindex = minIndex - 1;
    for (int index = minIndex; index < maxIndex; index++)
    {
        switch (checkdescending)
        {
            case true:
                if (array[index] > array[maxIndex])
                {
                    midindex++;
                    SwapPlaces(ref array[midindex], ref array[index]);
                }
                break;
            case false:
                if (array[index] < array[maxIndex])
                {
                    midindex++;
                    SwapPlaces(ref array[midindex], ref array[index]);
                }
                break;
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
#endregion

#region Selection Sort

void SelectionSortGroup(int[] nums, bool checkdescending = false)
{
    for (int i = 0; i < nums.Length - 1; i++)
    {
        int minmax = i;
        for (int j = i + 1; j < nums.Length; j++)
        {
            switch (checkdescending)
            {
                case true:
                    if (nums[j] > nums[minmax]) minmax = j;
                    break;
                case false:
                    if (nums[j] < nums[minmax]) minmax = j;
                    break;
            }
        }
        var temp = nums[i];
        nums[i] = nums[minmax];
        nums[minmax] = temp;
    }
}

#endregion