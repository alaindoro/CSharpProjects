using System;
using SimpleGoalManager.Model;

namespace SimpleGoalManager.Controller
{
    public class CreateAction : BaseAction, IAction
    {
        private readonly IStorage _storage;
        
        public string Name => "Добавить запись";
        
        public CreateAction(IStorage storage)
        {
            _storage = storage;
        }        
        
        public void Run()
        {
            Console.Clear();
            
            var todo = ReadText("Что сделать", 16, true);
            var deadline = ReadDateTime("Введите срок выполнения задачи");
            var priority = ReadNumber("Введите приоритет задачи", 1, 5);
            var details = ReadText("Примечание", int.MaxValue, false);
            
            var goal = new Goal(todo, deadline, priority, details);
            var result = _storage.Create(goal);
            Console.WriteLine(result ? "Новая запись успешно создана" : "Такая запись уже существует");
            Console.ReadLine();            
        }
    }
}