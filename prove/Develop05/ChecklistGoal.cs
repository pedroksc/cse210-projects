public class ChecklistGoal : Goal
{
    private int _bonus;
    private int _target;
    private int _completedCount;

    public ChecklistGoal(string name, string description, int points, int bonus, int target, int completedCount = 0)
        : base(name, description, points)
    {
        _bonus = bonus;
        _target = target;
        _completedCount = completedCount;
    }

    public override int RecordEvent()
    {
        if (IsComplete())
        {
            Console.WriteLine("You've already finished this checklist goal!");
            return 0;
        }

        _completedCount++;
        int earned = GetPoints();

        if (_completedCount == _target)
        {
            earned += _bonus;
            Console.WriteLine($"  ** Goal complete! Bonus of {_bonus} points earned! **");
        }

        return earned;
    }

    public override bool IsComplete() => _completedCount >= _target;

    public override string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {GetName()} ({GetDescription()}) -- Currently completed: {_completedCount}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{GetName()},{GetDescription()},{GetPoints()},{_bonus},{_target},{_completedCount}";
    }
}