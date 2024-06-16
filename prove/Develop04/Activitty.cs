using System;
using System.Threading;

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

    public void DelayAnimation(float time)
    {
        Console.WriteLine("Animation for {0} seconds...", time);
        Thread.Sleep((int)(time * 1000));
    }

    public void CongratulateUser()
    {
        Console.WriteLine("Congratulations! You've completed the activity.");
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
        DelayAnimation(Time);
        CongratulateUser();
    }
}
