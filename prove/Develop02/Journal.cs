using System;
using System.IO;

public class Journal
{
    private List<Entry> entries;
    private List<string> prompts;
    private string importLocation;
    private string exportLocation;

    private Random random;

    public Journal()
    {
        entries = new List<Entry>();
        prompts = new List<string> { 
            "What happened today?", 
            "What was the best thing that happened today?", 
            "What was the worst thing that happened today?",
            "What was the most interesting thing I saw or heard today?",
            "What was the most challenging thing I faced today",
            "What am I grateful for today?",
            "What did I learn today?",
            "What was the most fun thing I did today?",
            "What was the most surprising thing that happened today?",
            "What did I do today that I am proud of?"
             };
        random = new Random(); 
    }

    public List<string> NewEntry()
    {
        var entryDetails = new List<string>();
        
        // current date
        string dateText = DateTime.Now.ToString();
        entryDetails.Add(dateText);
        
        //random prompt
        int promptIndex = random.Next(prompts.Count);
        string selectedPrompt = prompts[promptIndex];
        entryDetails.Add(selectedPrompt);

        Console.WriteLine($"Prompt: {selectedPrompt}");
        Console.WriteLine("Enter your response:");
        entryDetails.Add(Console.ReadLine());

        var entry = new Entry(entryDetails[0], entryDetails[1], entryDetails[2]);
        entries.Add(entry);
        return entryDetails;
    }

    public void DisplayEntries()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.GetPrompts());
        }
    }

    public void Import(string path)
    {
        importLocation = path;
        var importedEntries = File.ReadAllLines(importLocation);
        foreach (var entryLine in importedEntries)
        {
            var parts = entryLine.Split(',');
            if (parts.Length == 3)
            {
                var entry = new Entry(parts[0], parts[1], parts[2]);
                entries.Add(entry);
            }
        }
    }

    public void Export(string path)
    {
        exportLocation = path;
        using (var writer = new StreamWriter(exportLocation))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Text}");
            }
        }
    }
}
