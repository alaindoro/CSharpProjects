using System;
using System.Linq;
using SimpleGoalManager.Model;

namespace SimpleGoalManager.Controller
{
    public class ListAction : BaseAction, IAction
    {
        private readonly IStorage _storage;

        private readonly string[] _options =
        {
            "По названию",
            "По сроку",
            "По приоритету",
        };

        public string Name => "Список записей";

        public ListAction(IStorage storage)
        {
            _storage = storage;
        }

        public void Run()
        {
            Console.Clear();
            Console.WriteLine("Сортировать записи");
            PrintOptions(_options);
            var option = ReadNumber("Введите номер операции", 0, _options.Length);
            if (option > 0)
            {
                var mode = GetSortMode(option);
                var goals = _storage.Find(mode);
                PrintFilteredTasks(goals.ToArray());
                Console.ReadLine();
            }
        }

        private SortMode GetSortMode(int option)
        {
            switch (option)
            {
                case 1: return SortMode.Todo;
                case 2: return SortMode.Deadline;
                case 3: return SortMode.Priority;
                default: throw new ArgumentException("Option unknown value");
            }
        }

        private void PrintFilteredTasks(Goal[] goals)
        {
            if (goals.Length > 0)
            {
                const string template = "{1,16}{2,12:g}{3,8} {4}";
                PrintTaskTable("Выбранные записи", goals, template);
            }
            else
            {
                Console.WriteLine("Записи выбранной категории не найденны");
            }
        }
    }
}