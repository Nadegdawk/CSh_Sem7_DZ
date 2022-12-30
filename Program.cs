Main();

void Main()
{
	bool isWorking = true;
	while (isWorking)
	{
		Console.Write("Input command: ");
		switch (Console.ReadLine())
		{
			case "Task47": Task47(); break;
			case "Task50": Task50(); break;
			case "Task52": Task52(); break;
			case "exit": isWorking = false; break;
		}
		Console.WriteLine();
	}
}

void Task47()
// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

{
	Console.WriteLine("Array of real numbers MxN");
	int m = ReadInt("M");
    	int n = ReadInt("N");
	int[,] array = GetArray(m, n);
    	double[,] arrayD = GetRandomArrayDouble(array);
	PrintArrayDouble(arrayD);
	Console.WriteLine();
}

void Task50()
// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

{
	Console.WriteLine("Array of real numbers MxN");
	int m = ReadInt("M");
    	int n = ReadInt("N");
    	int x = ReadInt("row");
    	int y = ReadInt("column");
    	int[,] array = GetArray(m, n);
   	PrintArray2(array);
   	ElementArray(x, y, array);
}

void Task52()
// Задача 52. Задайте двумерный массив из целых чисел. 
// Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

{
	Console.WriteLine("Array of real numbers MxN");
	int m = ReadInt("M");
    	int n = ReadInt("N");
    	int[,] array = GetArray(m, n);
    	PrintArray2(array);
    	PrintArray(AverColumns(array));
	}


int ReadInt(string argumentName)            //ввод данных пользователем
{
	Console.Write($"Input {argumentName}: ");
	return int.Parse(Console.ReadLine());
}

void PrintArray (double[] array)		//печать массива
{
	for (int i = 0; i < array.Length; i++)
	{
		Console.Write($"{Math.Round(array[i],2)}; ");
	}
}

void PrintArray2 (int[,] array)     //печать двумерного массива
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} | ");
        }
        Console.WriteLine();
    }
}

void PrintArrayDouble (double[,] array) //печать двумерного массива веществ.чисел
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
}

int[,] GetArray (int length, int secondLength)      //создание рандомного двумерного массива (-10, 10)
{
    int[,] array = new int[length, secondLength]; 
    Random random = new Random();
    for (int i = 0; i < length; i++)
    {
        for (int j = 0; j < secondLength; j++)
        {
            array[i, j] = random.Next(-10, 10);  
        }
    }
    return array;
}

double[,] GetRandomArrayDouble (int[,] array)    //создание рандомного массива веществ. чисел
{
	double[,] arrayD = new double[array.GetLength(0), array.GetLength(1)];
	Random random = new Random();

	for (int i = 0; i < array.GetLength(0); i++)
	{
		for (int j = 0; j < array.GetLength(1); j++)
        {
            arrayD[i, j] = Math.Round(array[i, j] + random.NextDouble(), 1);
        }
    }
	return arrayD;
}

void ElementArray (int x, int y, int[,] array)      //вывод элемента по индексу
{
    if (x > array.GetLength(0) | y > array.GetLength(1)) 
        System.Console.WriteLine($"Element {x},{y} is not in the array");
    else System.Console.WriteLine($"Element ({x},{y}) is {array[x-1,y-1]}");
}

double[] AverColumns (int[,] array)     //расчет среднего арифм. по столбцу
{
    double[] averCol = new double[array.GetLength(1)];
    double[] sum = new double[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(1); i++)
    {
        for (int j = 0; j < array.GetLength(0); j++)
        {
            sum [i] += array[j, i];
        }
        averCol[i] = sum[i] / array.GetLength(0);
    }
    return averCol;
}
