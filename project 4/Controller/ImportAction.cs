using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using SimpleGoalManager.Model;

namespace SimpleGoalManager.Controller
{
    public class ImportAction : BaseAction, IAction
    {
        private readonly IStorage _storage;

        public  string Name => "Импорт";

        public ImportAction(IStorage storage)
        {
            _storage = storage;
        }

        public  void Run()
        {
            Console.Clear();

            var result = 0;
            var beginDate = ReadDateTime("\nВведите дату начала диапазона импорта");
            var endDate = ReadDateTime("\nВведите дату конца диапазона Импорта");
            var fullPatch = ReadText("\nВведите путь и имя файла", Int32.MaxValue, true);            
            
            if (File.Exists(fullPatch))
            {
                var tasks = ImportRecordsFromFile(fullPatch);
                var filteredTasks = FilterRecordsByDateRange(tasks, beginDate, endDate);
                result = _storage.Merge(filteredTasks);
            }

            Console.WriteLine(result != 0 ? $"\nИмпортированно {result} записей" : "\nНет записей в выбранном диапазоне");
            Console.ReadLine();            
        }

        private IEnumerable<Goal> ImportRecordsFromFile(string fullPatch)
        {
            using var reader = new StreamReader(fullPatch);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            return csv.GetRecords<Goal>();
        }

        private IEnumerable<Goal> FilterRecordsByDateRange(IEnumerable<Goal> tasks, DateTime beginDate, DateTime endDate)
        {
            return tasks.ToList().FindAll(g => beginDate <= g.Deadline && g.Deadline <= endDate);
        }
    }
}