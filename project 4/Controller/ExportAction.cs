using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using SimpleGoalManager.Model;

namespace SimpleGoalManager.Controller
{
    public class ExportAction : BaseAction, IAction
    {
        private readonly IStorage _storage;
        
        public  string Name => "Экспорт";

        public ExportAction(IStorage storage)
        {
            _storage = storage;
        }

        public  void Run()
        {
            Console.Clear();
            
            var tasks = _storage.Find().ToArray();
            
            const string template = "{1,12:g}{2,6}{3,6}{4,12}";
            PrintTaskTable("Полный список задач", tasks, template);

            var beginDate = ReadDateTime("\nВведите дату начала диапазона экспорта");
            var endDate = ReadDateTime("nВведите дату конца диапазона экспорта");
            var fullPatch = ReadText("\nВведите путь и имя файла", int.MaxValue, true);            
            
            var exportedGoals = _storage.Find(beginDate, endDate).ToList();
            
            WriteFile(exportedGoals, fullPatch);
            
            var result = exportedGoals.Count();
            
            Console.WriteLine(result > 0 ? $"\nЭкспортировано {result} записей" : "\nНет записей в выбранном диапазоне");

            Console.ReadLine();            
        }

        private void WriteFile(IEnumerable<Goal> tasks, string fullPatch)
        {
            using var writer = new StreamWriter(fullPatch,false);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(tasks);
        }
        
    }
}