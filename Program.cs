/*
Задача 56: 
Задайте прямоугольный двумерный массив. 
Напишите программу, которая будет находить строку с наименьшей суммой элементов.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Программа считает сумму элементов в каждой строке и 
выдаёт номер строки с наименьшей суммой элементов: 1 строка
*/

Console.Write("Введите количество строчек : ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите количество столбцов : ");
int columns = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите минимальное число диапазона чисел из которого будут заполнены элементы массива  : ");
int minElements = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите максимальное число диапазона чисел из которого будут заполнены элементы массива  : ");
int maxElements = Convert.ToInt32(Console.ReadLine());


int[,] resMatrix = GetMatrix(rows, columns, minElements, maxElements);

// rows = 3 columns = 4 => таблица из 3-х строк и 4 -х столбцов, элемент: число от min до max включительно
Console.WriteLine();
PrintMatrix(resMatrix); // PrintMatrix(матрица)
Console.WriteLine();
//SumOfElementsInARow(resMatrix);
//PrintMatrix(resMatrix);
//SumOfElementsInARow(resMatrix);
//
Console.WriteLine($"Строчка с наименьшей суммой: {SumOfElementsInARow(resMatrix)+1}");
int[,] GetMatrix(int m, int n, int minElements, int maxElements)
{
    int[,] matrix = new int[m,n]; // Таблица из m - строк и n - столбцов
    for (int i = 0; i < matrix.GetLength(0); i++) // Цикл по строчкам, i < m
    {
       // i, j, m, k
       for (int j = 0; j < matrix.GetLength(1); j++) // Цикл по столбцам, j < n
       {
        matrix[i, j] = new Random().Next(minElements, maxElements+1);
       } 
    }
    return matrix;
}
// Метод, который печатает массив
void PrintMatrix(int[,] array2D)
{
    for (int i = 0; i < array2D.GetLength(0); i++) // строчки
    {
       for (int j = 0; j < array2D.GetLength(1); j++) // столбцы
       {
        Console.Write(array2D[i, j] + "\t"); // "\t" = Tab = 4 пробела между элементами
       } 
       Console.WriteLine();
    }

}
// Метод считает сумму элементов в каждой строке и 
// выдаёт номер строки с наименьшей суммой элементов
int SumOfElementsInARow(int[,] array2D)

{
    int rowWithMinSum = 0;
    int minSum = 0;
    for (int i = 0; i < array2D.GetLength(1); i++)
    {
        minSum = minSum + array2D [0, i]; // minSum = сумме элементов 0-й строчки
        
    }
        Console.WriteLine($"Сумма 1 строчки = {minSum}");
        for (int i = 1; i < array2D.GetLength(0); i++)
        {
        int sum = 0;
            for (int j = 0; j < array2D.GetLength(1); j++)
            {
            sum = sum + array2D[i, j]; //  сумма элементов текущей строчки, 
            // начиная от 1-ой
            }
            Console.WriteLine($"Сумма {i+1} строчки = {sum}");
            if (sum<minSum)
            {
            minSum = sum; // если сумма текущей строчки меньше предполагаемой 
            // минимальной суммы, то мы перезаписываем переменную
            rowWithMinSum = i;
             }
        }
        return rowWithMinSum;
}


