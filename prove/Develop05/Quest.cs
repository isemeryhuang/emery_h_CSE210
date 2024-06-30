using System;
using System.Collections.Generic;

public class Quest
{
    private int score;
    private List<Goal> goals;

    public Quest()
    {
        score = 0;
        goals = new List<Goal>();
    }

    public void DisplayGoals()
    {
        foreach (var goal in goals)
        {
            Console.WriteLine(goal.GetName() + (goal.GetIsComplete() ? " [X]" : " [ ]") + (goal is ChecklistGoal checklistGoal ? $" Completed {checklistGoal.TimesCompleted}/{checklistGoal.ProgressPoints}" : ""));
        }
    }

    public void CreateNewGoals()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        Goal newGoal = null;

        switch (Console.ReadLine())
        {
            case "1":
                Console.Write("Enter goal name: ");
                string simpleName = Console.ReadLine();
                Console.Write("Enter points: ");
                int simplePoints = int.Parse(Console.ReadLine());
                newGoal = new SimpleGoal(simplePoints, simpleName);
                break;
            case "2":
                Console.Write("Enter goal name: ");
                string eternalName = Console.ReadLine();
                Console.Write("Enter points: ");
                int eternalPoints = int.Parse(Console.ReadLine());
                newGoal = new EternalGoal(eternalPoints, eternalName);
                break;
            case "3":
                Console.Write("Enter goal name: ");
                string checklistName = Console.ReadLine();
                Console.Write("Enter points: ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter progress points: ");
                int progressPoints = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(progressPoints, checklistPoints, checklistName);
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        if (newGoal != null)
        {
            goals.Add(newGoal);
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine("Score: " + score);
    }

    public void RecordEvent()
    {
        Console.WriteLine("Select a goal to record:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetName()}");
        }

        int goalIndex = int.Parse(Console.ReadLine()) - 1;

        if (goalIndex >= 0 && goalIndex < goals.Count)
        {
            Goal goal = goals[goalIndex];
            score += goal.GetPoints();
            goal.SetIsComplete();
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveGoals()
    {
        // Implementation for saving goals
    }

    public void LoadGoals()
    {
        // Implementation for loading goals
    }
}
