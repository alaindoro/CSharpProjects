using SimpleGoalManager.Controller;
using SimpleGoalManager.Repository;

namespace SimpleGoalManager
{

    internal class Program
    {

        private const string _fileName = @"HomeWork 0701.csv";

        public static void Main(string[] args)
        {
            IStorage storage = new CsvFileStorage(_fileName);
            storage.Open();

            // операции пользователя реализуют интерфейс IAction
            var actions = new IAction[]
            {
                new ListAction(storage),
                new CreateAction(storage),
                new EditAction(storage),
                new DeleteAction(storage),
                new ExportAction(storage),
                new ImportAction(storage)
            };

            IAction mainMenu = new MainMenu(actions);

            mainMenu.Run();

            storage.Close();
        }
    }
}