// Самсонов Артём Арменович БПИ238-2 вариант 1.
namespace Reader;
// Программа 1 для считывания файла с массивом и преобразование этго массива.
class Program
{
    static void Main(string[] args)
    {
        do
        {
            Console.Clear();
            // Очистка консоли для корректной возможности перезапуска программы.
            string file = Methods.FileReader();
            // Считывание файла. 
            double[][] array = Methods.AddArrayFromFile(file);
            // Считывание данных с файла в массив массивов.
            Console.WriteLine();
            Console.WriteLine("Массив до изменений:");
            Methods.OutputArray(array);
            Console.WriteLine();
            Methods.AddArray(ref array);
            Console.WriteLine();
            Console.WriteLine("Массив после изменений:");
            Methods.OutputArray(array);
            Console.WriteLine();
            Console.WriteLine("Нажмите Escape, чтобы завершить программу, или любую другую клавишу, чтобы перезапустить её");
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);
        // Пользователю предлагается выбор: перезапустить программу или завершить её. Проводится проверка нажатой клавиши.
    }
}

