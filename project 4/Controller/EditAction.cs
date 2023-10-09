using System;
using System.Linq;
using SimpleGoalManager.Model;

namespace SimpleGoalManager.Controller
{
    public class EditAction : BaseAction, IAction
    {
        private readonly IStorage _storage;
        public  string Name => "Изменить запись";

        public EditAction(IStorage storage)
        {
            _storage = storage;
        }

        public void Run()
        {
            Console.Clear();

            var tasks = _storage.Find().ToArray();
            PrintTaskTable("Список задач", tasks, "{0,4}. {4}");

            var num = ReadNumber("\nВведите номер записи или 0 для отмены", 0, tasks.Length);

            if (num > 0)
            {
                var goal = tasks[num - 1];
                const string template = "{1,16}{2,12:g}{3,4} {4}";
                PrintTaskTable("Содержание записи", new[] {goal}, template);

                var deadline = ReadDateTime("Введите новый срок выполнения задачи");
                var priority = ReadNumber("Введите приоритет задачи", 1, 5);
                var details = ReadText("Примечание", int.MaxValue, false);                
                
                var newGoal = new Goal(goal.Todo, deadline, priority, details);

                var result = _storage.Update(newGoal);

                Console.WriteLine(result ? "Запиись успешно обновлена" : "Не удалось обновить запиись");
                Console.ReadLine();
            }
        }
    }
}