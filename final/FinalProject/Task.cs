using System;

public abstract class Task
{
    // Attributes
    private string _title;
    private string _description;
    private DateTime _dueDate;
    private int _priority;
    private bool _isComplete;

    // Properties
    public string Title { get => _title; set => _title = value; }
    public string Description { get => _description; set => _description = value; }
    public DateTime DueDate { get => _dueDate; set => _dueDate = value; }
    public int Priority { get => _priority; set => _priority = value; }
    public bool IsComplete { get => _isComplete; set => _isComplete = value; }

    // Methods
    public abstract void CompleteTask();
    public abstract void DisplayTask();
    public abstract string Serialize();
    public abstract void Deserialize(string[] data);
}
