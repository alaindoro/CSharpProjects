using System;
using System.Collections.Generic;
using SimpleGoalManager.Model;

namespace SimpleGoalManager
{
    public enum SortMode
    {
        Todo,
        Deadline,
        Priority
    }

    public interface IStorage
    {
        void Open();
        void Close();
        IEnumerable<Goal> Find(SortMode mode = SortMode.Deadline);
        IEnumerable<Goal> Find(DateTime begin, DateTime end, SortMode mode = SortMode.Deadline);
        bool Create(Goal entity);
        bool Delete(Goal entity);
        bool Update(Goal entity);
        int Merge(IEnumerable<Goal> entity);  
    }
}