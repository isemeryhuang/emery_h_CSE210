using System;

class Program
{
    private const string Value = "Enter the save file name: ";

    public static void Main(string[] args)
    {
        var journal = new Journal();
        bool running = true;

        while (running)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.WriteLine("please select one of the following option: ");
            Console.WriteLine("1. New Entries");
            Console.WriteLine("2. Display Entries");
            Console.WriteLine("3. Load Entries");
            Console.WriteLine("4. Save Entries");
            Console.WriteLine("5. Quit");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    journal.NewEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter the file name: ");
                    var importPath = Console.ReadLine();
                    journal.Import(importPath);
                    break;
                case "4":
                    Console.Write(Value);
                    var exportPath = Console.ReadLine();
                    journal.Export(exportPath);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Try again.");
                    break;
            }
        }
    }
}