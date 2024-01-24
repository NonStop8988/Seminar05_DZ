// Задача 4*(не обязательная): Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец, на пересечении которых расположен наименьший элемент массива. Под удалением понимается создание нового двумерного массива без строки и столбца.

// Функция - создание двумерного массива из случайных чисел
int[,] CreateTwoDimensionalArray(int n)
{
    Random rnd = new Random();
    int[,] array = new int[n, n];
    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++) 
        {
            array[i, j] = rnd.Next(0, 10);
        }
    }
    return array;
}

// Функция - вывод на экран двумерного массива
void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write($"Строка массива {i}: ");
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

// Функция - поиск значения минимального элемента двумерного массива
int FindMinElementArray(int[,] array)
{
    int minElement = array[0, 0];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < minElement)
            {
                minElement = array[i, j];
            }
        }
    }
    return minElement;
}

// Функция - поиск индекса строки минимального элемента двумерного массива
int FindMinIndexRowArray(int[,] array)
{
    int minElement = array[0, 0];
    int minRow = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < minElement)
            {
                minElement = array[i, j];
                minRow = i;
            }
        }
    }
    return minRow;
}

// Функция - поиск индекса столбца минимального элемента двумерного массива
int FindMinIndexColArray(int[,] array)
{
    int minElement = array[0, 0];
    int minCol = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < minElement)
            {
                minElement = array[i, j];
                minCol = j;
            }
        }
    }
    return minCol;
}

// Функция - вывод массива без строк и столбцов с наименьшим значением элемента
int[,] PrintArrayWithoutMin(int[,] array, int row, int col)
{
    int newRowCount = array.GetLength(0) - 1;
    int newColCount = array.GetLength(1) - 1;
    int[,] newArray = new int[newRowCount, newColCount];

    for (int i = 0, newRow = 0; i < array.GetLength(0); i++)
    {
        if (i == row)
        {
            continue;
        }
            
        for (int j = 0, newCol = 0; j < array.GetLength(1); j++)
        {
            if (j == col)
            {
                continue;
            }
            newArray[newRow,newCol] = array[i,j];
            newCol++;
        }
        newRow++;
    }
    return newArray;
}

// Ввод данных
Console.Clear();
bool workProgramm = true;

while (workProgramm)
{
    Console.Write("Введите число больше 1: ");
    int number = int.Parse(Console.ReadLine()!);
    if (number > 1)
    {
        int[,] array = CreateTwoDimensionalArray(number);
        PrintArray(array);
        int minElement = FindMinElementArray(array);
        int minRow = FindMinIndexRowArray(array);
        int minCol = FindMinIndexColArray(array);
        int[,] arrayWithoutMinElem = PrintArrayWithoutMin(array, minRow, minCol);
        Console.WriteLine($"Новый массив с удаленными строкой [{minRow}] и столбцом [{minCol}] минимального элемента ({minElement}):");
        PrintArray(arrayWithoutMinElem);
        workProgramm = false;
    }
    else 
    {
        Console.WriteLine("Введено неверное число");
    }
}