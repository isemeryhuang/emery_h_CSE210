using System;

public class Word
{
    private string word;
    private bool isBlank;
    private int wordLen;

    public Word(string word)
    {
        this.word = word;
        this.isBlank = false;
        this.wordLen = word.Length;
    }

    public string GetWord()
    {
        return isBlank ? new string('_', wordLen) : word;
    }

    public void Blank()
    {
        isBlank = true;
    }

    public bool CheckBlank()
    {
        return isBlank;
    }
}
