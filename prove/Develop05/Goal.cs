public abstract class Goal
{
    protected int points;
    protected bool isComplete;
    protected string name;

    protected Goal(int points, string name)
    {
        this.points = points;
        this.name = name;
        this.isComplete = false;
    }

    public int GetPoints()
    {
        return points;
    }

    public bool GetIsComplete()
    {
        return isComplete;
    }

    public void SetIsComplete()
    {
        isComplete = true;
    }

    public string GetName()
    {
        return name;
    }
}
