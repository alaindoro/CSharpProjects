using System;
using System.Linq;

namespace SimpleGoalManager.Controller
{
    public class DeleteAction : BaseAction, IAction
    {
        private readonly IStorage _storage;

        public string Name => "Удалить запись";

        public DeleteAction(IStorage storage)
        {
            _storage = storage;
        }

        public void Run()
        {
            Console.Clear();

            var tasks = _storage.Find().ToArray();
            
            const string template = "{0,4}. {1}";
            
            PrintTaskTable("Список задач", tasks, template);

            var num = ReadNumber("\nВведите номер для удаления или 0 для отмены", 0, tasks.Length);
            if (num > 0)
            {
                var task = tasks[num - 1];
                var result = _storage.Delete(task);
                Console.WriteLine(result ? "\nЗппись успешно удалена" : "\nТакая зпись не найдена");
                Console.ReadLine();
            }
        }
    }
}