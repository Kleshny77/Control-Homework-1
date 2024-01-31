// Самсонов Артём Арменович БПИ238-2 вариант 1.
using System;
namespace Writer
{
	public class OtherMethods
    // Класс со всеми остальными методами второго проекта.
	{
        public static void AddArray(out double[,] array, int N, int M)
        // Метод для формирования массива.
        {
            array = new double[N, M];
            int rows = array.GetLength(0);
            // Строки/ряды массива.
            int columns = array.GetLength(1);
            // Столбцы массива.
            int numberElement = 1;
            // Вспомогательный счетчик для отслеживания номера элемента матрицы.
            for (int row = 0; row < rows; row++)
            // Цикл проходится по строкам матрицы.
            {
                for (int column = 0; column < columns; column++)
                // Цикл проходится по столбцам конкретной строки матрицы.
                {
                    array[row, column] = Convert.ToDouble(2 * numberElement + 10) / Convert.ToDouble(3 * numberElement - 10);
                    // Заполнение ячейки по формуле. Конвертация в double, чтобы деление происходило корректно (избегание случаев, когда int/int).
                    numberElement++;
                }
            }
        }

        public static StreamWriter CreateFile()
        // Метод по созданию файла с заданным именем в директории с исполнимым проектом.
        {
            string fileName = InputReader.InputString("Имя файла, в который вы хотите сохранить массив А");
            string projectDirectory = Directory.GetCurrentDirectory();
            // Возвращает директорию с исполнимым файлом.
            string filePath = $"{projectDirectory}/{fileName}.txt";
            // Создание полного пути к новой директории с расширением .txt.
            // Альтернативное решение: напрямую запрашиваем у пользователя полный путь к директории папки, в которой надо создать файл, и создаем по этому пути.
            StreamWriter file = null;
            try
            {
                file = File.CreateText(filePath);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Название файла содержит недопустимые символы ({ex.Message}).");
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"Длина к пути к файлу превышает максимально допустимое значение ({ex.Message}).");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine($"Директория не найдена ({ex.Message}).");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Неизвестная ошибка{ex.Message}.");
                // Все остальные возможные исключения.
            }
            return file;
        }

        public static void FillingFileDoubleMatrix(double[,] A, StreamWriter file)
        // Метод для заполнения файла матрицей с вещественными числами.
        {
            int rows = A.GetLength(0);
            // Строки матрицы.
            int columns = A.GetLength(1);
            // Столбцы матрицы.
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                // Два цикла для заполнения файла массивом чисел. 
                {
                    file.Write(A[row, column].ToString("F2"));
                    // Форматирование числа до двух знаков после запятой и написание этого числа в файл.
                    if (column == columns - 1)
                    {
                        file.Write(";");
                        // Разделение строк.
                    }
                    file.Write(" ");
                    // Разделение элементов одной строки пробелом.
                }
            }
            // Все числа записаны в файл в одну строку.
            file.Close();
        }
    }
}

