using System;


public class Verse
{
    private List<Word> words;

    public Verse(List<string> verse)
    {
        words = verse.Select(word => new Word(word)).ToList();
    }

    public string ModifyVerse()
    {
        var random = new Random();
        foreach (var word in words)
        {
            if (!word.CheckBlank() && random.Next(2) == 0) // Randomly decide to blank the word
            {
                word.Blank();
            }
        }
        return string.Join(" ", words.Select(word => word.GetWord()));
    }

    public void PrintVerse()
    {
        Console.WriteLine(string.Join(" ", words.Select(word => word.GetWord())));
    }

    public bool AllWordsBlank()
    {
        return words.All(word => word.CheckBlank());
    }
}
