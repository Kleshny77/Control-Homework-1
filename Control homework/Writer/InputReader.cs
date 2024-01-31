// Самсонов Артём Арменович БПИ238-2 вариант 1.
using System;
namespace Writer
{
	public class InputReader
	// Класс с методами второго проекта для считывания данных с консоли.
	{
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
    }
}

