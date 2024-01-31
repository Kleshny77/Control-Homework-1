// Самсонов Артём Арменович БПИ238-2 вариант 1.
using System;
namespace Reader
{
    public class Methods
    // Класс для методов второго проекта.
    {
        public static void OutputArray(double[][] array)
        {
            foreach (var row in array)
            {
                foreach (var element in row)
                {
                    Console.Write($"{element} ");
                }
                Console.WriteLine();
            }
        }

        public static string InputString(string name)
        // Метод для считывания переменной типа string.
        {
            string result;
            // Возвращаемая переменная. 
            bool flag;
            do
            {
                Console.Write($"{name} = ");
                result = Console.ReadLine();
                if (result == "")
                // Если пользователь просто нажал Enter.
                {
                    Console.WriteLine("Некорректный ввод, не оставляйте поле для ввода пустым");
                    flag = false;
                }
                else
                {
                    flag = true;
                }
            }
            while (!flag);
            // Цикл идёт до тех пор, пока пользователь не введет корректные данные.
            return result;
        }

        public static int InputInt(string name, double lowerBound = double.NegativeInfinity, double upperBound = double.PositiveInfinity, string lowerSing = "<", string upperSing = "<")
        // Метод для считывания с консоли переменной типа int и проверки этой переменной на ограничений. Если ограничений нет, то происходит такая проверка: -бесконечность < введенное число < +бесконечность.
        {
            bool flag;
            // Временная переменная для проверки на корректность ввода данных.
            int result;
            // Возвращаемая переменная.
            do
            {
                Console.Write($"{lowerBound} {lowerSing} {name} {upperSing} {upperBound}. {name} = ");
                // Предупреждение пользователя об ограничениях на переменную, которую надо ввести.
                if (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine("Некорректный ввод, повторите попытку");
                    flag = false;
                    // Срабатывает, если пользователь ввел любой символ, не содержащий цифр.
                }
                else
                {
                    bool flag1 = true;
                    // Временная переменная создания проерки на ограничения. Проверяет нижнее ограничение.
                    bool flag2 = true;
                    // Временная переменная создания проерки на ограничения. Проверяет верхнее ограничение.
                    switch (lowerSing)
                    {
                        case "<":
                            flag1 = lowerBound < result;
                            break;
                        case "<=":
                            flag1 = lowerBound <= result;
                            break;
                    }
                    switch (upperSing)
                    {
                        case "<":
                            flag2 = result < upperBound;
                            break;
                        case "<=":
                            flag2 = result <= upperBound;
                            break;
                    }
                    if (flag1 && flag2)
                    {
                        flag = true;
                    }
                    else
                    {
                        Console.WriteLine($"Введённые значения не подходят под ограничения. {lowerBound} {lowerSing} {name} {upperSing} {upperBound}");
                        flag = false;
                    }
                }
            }
            while (!flag);
            // Цикл повторяется до тех пор, пока пользователь не введет корректные значения.
            return result;
        }

        public static string FileReader()
        // Метод для считывания файла и проверка на исключения.
        {
            string file;
            while (true)
            {
                string fileName = Methods.InputString("Имя файла, который вы хотите открыть");
                string projectDirectory = Directory.GetCurrentDirectory();
                // Возвращает директорию с исполнимым файлом.
                string filePath = $"{projectDirectory}/{fileName}.txt".Replace("reader", "Writer");
                // Создание полного пути к новой директории с расширением txt.
                file = "";
                try
                {
                    file = File.ReadAllText(filePath);
                    // Считывание файла в одну строку.
                    break;
                }
                catch (FileNotFoundException ex)
                {
                    Console.WriteLine($"Файл по указанному пути не найден ({ex.Message}).");
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine($"Отсутствуют права доступа к файлу ({ex.Message}).");
                }
                catch (PathTooLongException ex)
                {
                    Console.WriteLine($"Путь к файлу слишком длинный ({ex.Message}).");
                }
                catch (DirectoryNotFoundException ex)
                {
                    Console.WriteLine($"Путь к файлу содержит недопустимую директорию ({ex.Message}).");
                }
                catch (IOException ex)
                {
                    Console.WriteLine($"Ошибка ввода-вывода ({ex.Message}).");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Неизвестная ошибка ({ex.Message}).");
                    // Все остальные ислючения.
                }
            }
                return file.ToString();
        }
        public static double[][] AddArrayFromFile(string file)
        // Метод для считывания чисел с файла и добавления их в массив массивов.
        {
            string[] rows = file.Split(';', StringSplitOptions.RemoveEmptyEntries);
            double[][] array = new double[rows.Length][];
            for (int i = 0; i < rows.Length; i++)
            {
                string[] column = rows[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                array[i] = new double[column.Length];
                for (int j = 0; j < column.Length; j++)
                {
                    if (!double.TryParse(column[j], out array[i][j]))
                    {
                        Console.WriteLine("Неккоректные данные в файле");
                    }
                }
            }
            return array;
        }

        public static void AddArray(ref double[][] array)
        // Метод для циклического сдвига элементов массива.
        {
            int k = Methods.InputInt("k", lowerBound: 0, lowerSing: "<=");
            for (int z = 0; z < array.Length - 1; z++)
            {
                var row = array[z];
                int length = row.Length;
                k = k % length;
                k -= 1;
                // Обработка случая, если k > length.
                double[] temp = new double[length];
                for (int i = 0; i < length; i++)
                {
                    int newIndex = (i - k + length) % length;
                    temp[newIndex] = row[i];
                }
                for (int i = 0; i < length; i++)
                // Цикл для копирования элементов обратно в исходный массив.
                {
                    row[i] = temp[i];
                }
            }
        }
    }
}

