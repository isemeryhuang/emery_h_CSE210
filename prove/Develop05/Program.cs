using System;

public class Program
{
    public static void Main(string[] args)
    {
        Quest quest = new Quest();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Load Goals");
            Console.WriteLine("7. Exit");

            switch (Console.ReadLine())
            {
                case "1":
                    quest.CreateNewGoals();
                    break;
                case "2":
                    quest.RecordEvent();
                    break;
                case "3":
                    quest.DisplayGoals();
                    break;
                case "4":
                    quest.DisplayScore();
                    break;
                case "5":
                    quest.SaveGoals();
                    break;
                case "6":
                    quest.LoadGoals();
                    break;
                case "7":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
