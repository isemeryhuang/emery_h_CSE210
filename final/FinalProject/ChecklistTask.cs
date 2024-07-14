using System;
using System.Collections.Generic;

public class ChecklistTask : Task
{
    // Attributes
    private List<string> _checklistItems;

    // Constructor
    public ChecklistTask()
    {
        _checklistItems = new List<string>();
    }

    // Properties
    public List<string> ChecklistItems { get => _checklistItems; set => _checklistItems = value; }

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
        Console.WriteLine("Checklist:");
        foreach (var item in ChecklistItems)
        {
            Console.WriteLine($" - {item}");
        }
        Console.WriteLine($"Completed: {IsComplete}");
    }

    // Serialize method
    public override string Serialize()
    {
        return $"ChecklistTask|{Title}|{Description}|{DueDate}|{Priority}|{IsComplete}|{string.Join(",", ChecklistItems)}";
    }

    // Deserialize method
    public override void Deserialize(string[] data)
    {
        Title = data[1];
        Description = data[2];
        DueDate = DateTime.Parse(data[3]);
        Priority = int.Parse(data[4]);
        IsComplete = bool.Parse(data[5]);
        ChecklistItems = new List<string>(data[6].Split(','));
    }
}
