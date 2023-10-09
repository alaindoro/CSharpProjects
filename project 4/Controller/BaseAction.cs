using System;
using SimpleGoalManager.Model;

namespace SimpleGoalManager.Controller
{
    public abstract class BaseAction
    {
        protected string ReadText(string title, int maxLength, bool isRequired)
        {
            Console.WriteLine(title);
            string input;
            while (true)
            {
                input = Console.ReadLine() ?? string.Empty;
                bool isNotEmpty = !string.IsNullOrEmpty(input);
                if (isRequired & !isNotEmpty)
                {
                    Console.WriteLine($"Неверное значение, строка не может быть пуста");
                    continue;
                }

                if (isRequired & isNotEmpty && input.Length > maxLength)
                {
                    Console.WriteLine($"Неверное значение, введите строку не более {maxLength} символов");
                    continue;
                }

                break;
            }

            return input;
        }

        protected DateTime ReadDateTime(string title)
        {
            Console.WriteLine(title);
            DateTime date;
            while (true)
            {
                var input = Console.ReadLine();
                var hasResult = DateTime.TryParse(input, out date);
                if (hasResult) break;
                Console.WriteLine("Неверное значение, введите дату и время в формате ДД.ММ.ГГ ЧЧ:ММ");
            }

            return date;
        }

        protected int ReadNumber(string title, int min, int max)
        {
            Console.WriteLine(title);
            int input;
            while (true)
            {
                var hasResult = int.TryParse(Console.ReadLine(), out input);
                if (hasResult && input >= min && input <= max) break;
                Console.WriteLine($"Неверное значение, введите число от {min} до {max}");
            }

            return input;
        }

        protected void PrintOptions(string[] options)
        {
            for (var i = 0; i < options.Length; i++)
                Console.WriteLine($"{i + 1}. {options[i]}");

            Console.WriteLine("0. Выход");
        }

        protected void PrintTaskTable(string title, Goal[] goals, string template)
        {
            Console.WriteLine(title);
            for (var i = 0; i < goals.Length; i++)
            {
                Console.WriteLine(template,
                    i + 1,
                    goals[i].Todo,
                    goals[i].Deadline,
                    goals[i].Priority,
                    goals[i].Details
                );
            }
        }
    }
}