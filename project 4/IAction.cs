namespace SimpleGoalManager
{
    public interface IAction
    {
        string Name { get; }
        void Run();        
    }
}