using System;

namespace SimpleGoalManager.Controller
{
    public class MainMenu : BaseAction, IAction
    {
        private readonly IAction[] _actions;
        private readonly string[] _options;

        public string Name => "Главное меню";

        public MainMenu(IAction[] actions)
        {
            _actions = actions;
            _options = new string[_actions.Length];

            for (var i = 0; i < _actions.Length; i++) _options[i] = _actions[i].Name;
        }

        public void Run()
        {
            int option;
            do
            {
                Console.Clear();
                Console.WriteLine(Name);
                PrintOptions(_options);
                option = ReadNumber("\nВведите номер операции", 0, _actions.Length);
                if (option > 0) _actions[option - 1].Run();
            } while (option > 0);
        }
    }
}