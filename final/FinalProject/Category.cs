using System;
using System.Collections.Generic;

public class Category
{
    // Attributes
    private string _name;
    private List<Task> _tasks;

    // Constructor
    public Category()
    {
        _tasks = new List<Task>();
    }

    // Properties
    public string Name { get => _name; set => _name = value; }
    public List<Task> Tasks { get => _tasks; set => _tasks = value; }

    // Methods
    public void AddTask(Task task)
    {
        Tasks.Add(task);
    }

    public void RemoveTask(Task task)
    {
        Tasks.Remove(task);
    }

    public void DisplayTasks()
    {
        Console.WriteLine($"Category: {Name}");
        foreach (var task in Tasks)
        {
            task.DisplayTask();
            Console.WriteLine();
        }
    }

    // Serialize method
    public string Serialize()
    {
        List<string> taskData = new List<string>();
        foreach (var task in Tasks)
        {
            taskData.Add(task.Serialize());
        }
        return $"Category|{Name}|{string.Join(";", taskData)}";
    }

    // Deserialize method
    public void Deserialize(string[] data)
    {
        if (data.Length < 3) return;

        Name = data[1];
        Tasks = new List<Task>();
        var tasksData = data[2].Split(';');
        foreach (var taskData in tasksData)
        {
            var taskFields = taskData.Split('|');
            Task task;
            if (taskFields[0] == "SimpleTask")
            {
                task = new SimpleTask();
            }
            else
            {
                task = new ChecklistTask();
            }
            task.Deserialize(taskFields);
            Tasks.Add(task);
        }
    }
}
