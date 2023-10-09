using System;
using CsvHelper.Configuration.Attributes;

namespace SimpleGoalManager.Model
{
    public struct Goal
    {
        /*
         * [Name("todo")] и т.д. нужны для корректной работы библиотеки экспорта/импорта CsvHelper
         */        
        [Name("todo")] public string Todo { get; }
        [Name("deadline")] public DateTime Deadline { get; set; }
        [Name("priority")] public int Priority { get; set; }
        [Name("details")] public string Details { get; set; }

        public Goal(string todo, DateTime deadline, int priority, string details)
        {
            Todo = todo;
            Deadline = deadline;
            Priority = priority;
            Details = details;
        }

        public bool Equals(Goal other)
        {
            return Todo == other.Todo;
        }

        public override bool Equals(object obj)
        {
            return obj is Goal other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Todo != null ? Todo.GetHashCode() : 0;
        }
    }
}