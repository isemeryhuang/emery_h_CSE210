class MindfulnessProgram
{
    static void Main(string[] args)
    {
        Activity[] activities = new Activity[]
        {
            new BreathingExercise(),
            new BodyScan(),
            new MindfulWalking()
        };

        foreach (var activity in activities)
        {
            activity.RunActivity();
        }
    }
}
