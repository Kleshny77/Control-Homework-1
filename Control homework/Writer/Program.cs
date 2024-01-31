// Самсонов Артём Арменович БПИ238-2 вариант 1.
namespace Writer;
// Программа 1 для создания файла с заполненным массивом.
using System;
class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            // Очистка консоли для корректной возможности перезапуска программы.
            int N = InputReader.InputInt("N", 0, 15, "<", "<=");
            int M = InputReader.InputInt("M", 0, 10, "<", "<=");
            // Альтернативное решение: ввод двух чисел, разделенных пробелом с одной строки. Реализация через split(" ") и помещение этих чисел в массив string, затем две отдельных проверки нулевого элемента и первого элемента массива через метод InputInt. 
            double[,] A;
            OtherMethods.AddArray(out A, N, M);
            // Заполнение массива.
            StreamWriter file = OtherMethods.CreateFile();
            // Создание пустого файла.
            OtherMethods.FillingFileDoubleMatrix(A, file);
            // Заполнение этого файла нашей матрицей.
            Console.WriteLine("Нажмите Escape, чтобы завершить программу, или любую другую клавишу, чтобы перезапустить её");
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);
        // Пользователю предлагается выбор: перезапустить программу или завершить её. Проводится проверка нажатой клавиши.
    }
}