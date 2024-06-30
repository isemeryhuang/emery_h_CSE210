class Activity
{
    public float Time { get; set; }
    public string StartingMessage { get; set; }
    public string Description { get; set; }

    public Activity(float time, string startingMessage, string description)
    {
        Time = time;
        StartingMessage = startingMessage;
        Description = description;
    }

    public void PrintMessage()
    {
        Console.WriteLine(StartingMessage);
    }

    public void PrintDescription()
    {
        Console.WriteLine(Description);
    }

    public void RunActivity()
    {
        PrintMessage();
        PrintDescription();
        Console.WriteLine("Waiting for {0} seconds...", Time);
        System.Threading.Thread.Sleep((int)(Time * 1000));
        Console.WriteLine("Congratulations! You've completed the activity.");
    }
}
