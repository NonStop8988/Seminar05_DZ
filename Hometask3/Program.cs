// Задание 3. Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Функция - Вычисление сумм по строкам (на выходе массив с суммами строк)
int[] SumRows(int[,] array)
{
    int[] sum = new int [array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum[i] += array[i, j];
        }
    }
    return sum;
}

// Функция - Получение индекса минимального элемента в одномерном массиве
int MinIndex(int[] array)
{
    int minElemIndex = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] < array[minElemIndex])
        {
            minElemIndex = i;
        }
    }
    return minElemIndex;
}

// Ввод данных
int[,] numbers = new int[,]
{
    {1, 112, 3},
    {1, 1221, 10},
    {7, 18, 2},
    {9, 10, 11}
};

Console.Clear();
int[] sum = SumRows(numbers);
Console.WriteLine($"[{string.Join(", ", sum)}]");
int MinIndexRowArraySum = MinIndex(sum);
Console.WriteLine(MinIndexRowArraySum);