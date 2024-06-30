public class ChecklistGoal : Goal
{
    public int TimesCompleted { get; private set; }
    public int ProgressPoints { get; private set; }

    public ChecklistGoal(int progressPoints, int points, string name) : base(points, name)
    {
        this.ProgressPoints = progressPoints;
        this.TimesCompleted = 0;
    }

    public new int GetPoints()
    {
        TimesCompleted++;
        return TimesCompleted == ProgressPoints ? points + 500 : points; // Extra bonus on completion
    }

    public new void SetIsComplete()
    {
        if (TimesCompleted >= ProgressPoints)
        {
            isComplete = true;
        }
    }
}
