using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using SimpleGoalManager.Model;

namespace SimpleGoalManager.Repository
{
    public class CsvFileStorage : IStorage
    {
        private const StringComparison _comparison = StringComparison.InvariantCultureIgnoreCase;
        // HashSet позволяет сохранять только уникальные записи
        private readonly HashSet<Goal> _goals;
        private readonly string _fileName;

        public CsvFileStorage(string fileName)
        {
            _goals = new HashSet<Goal>();
            _fileName = fileName;
        }

        public void Open()
        {
            if (!File.Exists(_fileName)) return;
            using var reader = new StreamReader(_fileName);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            var records = csv.GetRecords<Goal>();
            Merge(records);
        }

        public void Close()
        {
            using var writer = new StreamWriter(_fileName, false);
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.WriteRecords(_goals);
        }

        public IEnumerable<Goal> Find(SortMode mode = SortMode.Deadline)
        {
            Predicate<Goal> condition = g => true;
            Comparison<Goal> comparer = GetComparer(mode);
            return Find(condition, comparer);
        }

        public IEnumerable<Goal> Find(DateTime begin, DateTime end, SortMode mode = SortMode.Deadline)
        {
            Predicate<Goal> condition = g => begin <= g.Deadline && g.Deadline <= end;
            Comparison<Goal> comparer = GetComparer(mode);
            return Find(condition, comparer);
        }

        private IEnumerable<Goal> Find(Predicate<Goal> condition, Comparison<Goal> comparer)
        {
            var result = _goals.ToList().FindAll(condition);
            result.Sort(comparer);
            return result;
        }

        /// <summary>
        /// Возвращает компаратор - функцию сравнивающую "цели" по определенным полям, для сортировки
        /// </summary>
        private Comparison<Goal> GetComparer(SortMode mode)
        {
            switch (mode)
            {
                case SortMode.Todo:
                    return (g1, g2) => string.Compare(g1.Todo, g2.Todo, _comparison);
                case SortMode.Deadline:
                    return (g1, g2) => DateTime.Compare(g1.Deadline, g2.Deadline);
                case SortMode.Priority:
                    return (g1, g2) => g1.Priority - g2.Priority;
                default: throw new ArgumentException("SortMode unknown value");
            }
        }

        public bool Create(Goal entity)
        {
            return _goals.Add(entity);
        }

        public bool Delete(Goal entity)
        {
            return _goals.Remove(entity);
        }

        public bool Update(Goal entity)
        {
            return Delete(entity) && Create(entity);
        }

        public int Merge(IEnumerable<Goal> entity)
        {
            return entity.Count(task => _goals.Add(task));
        }
    }
}