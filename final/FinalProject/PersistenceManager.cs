using System.IO;

public class PersistenceManager
{
    // Methods
    public void SaveToFile(ToDoList toDoList, string filename)
    {
        var data = toDoList.Serialize();
        File.WriteAllText(filename, data);
    }

    public ToDoList LoadFromFile(string filename)
    {
        if (File.Exists(filename))
        {
            var data = File.ReadAllText(filename);
            var toDoList = new ToDoList();
            toDoList.Deserialize(data);
            return toDoList;
        }
        return new ToDoList();
    }
}
