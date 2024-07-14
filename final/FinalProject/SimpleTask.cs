using System;

public class SimpleTask : Task
{
    // Override CompleteTask method
    public override void CompleteTask()
    {
        IsComplete = true;
    }

    // Override DisplayTask method
    public override void DisplayTask()
    {
        Console.WriteLine($"Task: {Title}");
        Console.WriteLine($"Description: {Description}");
        Console.WriteLine($"Due Date: {DueDate}");
        Console.WriteLine($"Priority: {Priority}");
        Console.WriteLine($"Completed: {IsComplete}");
    }

    // Serialize method
    public override string Serialize()
    {
        return $"SimpleTask|{Title}|{Description}|{DueDate}|{Priority}|{IsComplete}";
    }

    // Deserialize method
    public override void Deserialize(string[] data)
    {
        Title = data[1];
        Description = data[2];
        DueDate = DateTime.Parse(data[3]);
        Priority = int.Parse(data[4]);
        IsComplete = bool.Parse(data[5]);
    }
}
