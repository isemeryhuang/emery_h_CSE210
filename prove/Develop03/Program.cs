using System;

public class Program
{
    private List<Verse> scripture;
    private string scriptureReference;
    private string fileAddress;

    public Program(string fileAddress)
    {
        this.fileAddress = fileAddress;
        scripture = new List<Verse>();
        FindVerse(fileAddress);
    }

    private void FindVerse(string fileAddress)
    {
        var lines = File.ReadAllLines(fileAddress);
        if (lines.Length > 0)
        {
            // select random scripture.
            var random = new Random();
            var randomLine = lines[random.Next(lines.Length)];
            
            // Only the word after ":" will disappeared after clicking enter.
            var parts = randomLine.Split(new[] { ": " }, 2, StringSplitOptions.None);
            if (parts.Length == 2)
            {
                scriptureReference = parts[0];
                scripture.Add(new Verse(parts[1].Split(' ').ToList()));
            }
        }
    }

    public void PrintScripture()
    {
        Console.Clear();
        Console.WriteLine(scriptureReference);
        foreach (var verse in scripture)
        {
            verse.PrintVerse();
        }
    }

    public static void Main(string[] args)
    {
        // Create a "scripture.txt" file for extra point.
        var program = new Program("scripture.txt");
        program.PrintScripture();

        while (true)
        {
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            var input = Console.ReadLine();
            if (input?.ToLower() == "quit")
            {
                Console.WriteLine("\nYou have quit the program.");
                break;
            }

            foreach (var verse in program.scripture)
            {
                verse.ModifyVerse();
            }

            program.PrintScripture();

            if (program.scripture.All(verse => verse.AllWordsBlank()))
            {
                Console.WriteLine("\nYou have hidden all the word. Program will exit now.");
            }
        }
    }
}
