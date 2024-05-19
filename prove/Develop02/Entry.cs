public class Entry
{
    public string Date;
    public string Prompt;
    public string Text;

    public Entry(string date, string prompt, string text)
    {
        Date = date;
        Prompt = prompt;
        Text = text;
    }

    public string GetPrompts()
    {
        return $"{Date} - {Prompt}: {Text}";
    }

    public void StoreRespond(List<string> responses)
    {
        if (responses.Count >= 3)
        {
            Date = responses[0];
            Prompt = responses[1];
            Text = responses[2];
        }
    }
}
