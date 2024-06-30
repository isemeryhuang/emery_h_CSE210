public class EternalGoal : Goal
{
    public EternalGoal(int points, string name) : base(points, name)
    {
    }

    public new void SetIsComplete()
    {
        // Eternal goals are never complete, so this method does nothing
    }
}
