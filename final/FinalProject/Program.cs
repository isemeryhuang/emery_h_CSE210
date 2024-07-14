using System;

class Program
{
    static void Main(string[] args)
    {
        var toDoList = new ToDoList();
        var persistenceManager = new PersistenceManager();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("To-Do List Program");
            Console.WriteLine("1. Add Category");
            Console.WriteLine("2. Add Task");
            Console.WriteLine("3. Display To-Do List");
            Console.WriteLine("4. Save To-Do List");
            Console.WriteLine("5. Load To-Do List");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddCategory(toDoList);
                    break;
                case "2":
                    AddTask(toDoList);
                    break;
                case "3":
                    toDoList.DisplayCategories();
                    break;
                case "4":
                    Console.Write("Enter filename to save: ");
                    var saveFilename = Console.ReadLine();
                    persistenceManager.SaveToFile(toDoList, saveFilename);
                    break;
                case "5":
                    Console.Write("Enter filename to load: ");
                    var loadFilename = Console.ReadLine();
                    toDoList = persistenceManager.LoadFromFile(loadFilename);
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void AddCategory(ToDoList toDoList)
    {
        Console.Write("Enter category name: ");
        var categoryName = Console.ReadLine();
        var category = new Category { Name = categoryName };
        toDoList.AddCategory(category);
    }

    static void AddTask(ToDoList toDoList)
    {
        Console.Write("Enter category name: ");
        var categoryName = Console.ReadLine();
        var category = toDoList.Categories.Find(c => c.Name == categoryName);
        if (category == null)
        {
            Console.WriteLine("Category not found.");
            return;
        }

        Console.WriteLine("1. Simple Task");
        Console.WriteLine("2. Checklist Task");
        Console.Write("Choose task type: ");
        var taskType = Console.ReadLine();

        Task task;
        if (taskType == "1")
        {
            task = new SimpleTask();
        }
        else if (taskType == "2")
        {
            task = new ChecklistTask();
        }
        else
        {
            Console.WriteLine("Invalid task type.");
            return;
        }

        Console.Write("Enter task title: ");
        task.Title = Console.ReadLine();
        Console.Write("Enter task description: ");
        task.Description = Console.ReadLine();
        
        DateTime dueDate;
        while (true)
        {
            Console.Write("Enter due date (MM/dd/yyyy): ");
            if (DateTime.TryParseExact(Console.ReadLine(), "MM/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out dueDate))
            {
                task.DueDate = dueDate;
                break;
            }
            else
            {
                Console.WriteLine("Invalid date format. Please enter the date in MM/dd/yyyy format.");
            }
        }

        Console.Write("Enter priority (1-5): ");
        task.Priority = int.Parse(Console.ReadLine());

        if (task is ChecklistTask checklistTask)
        {
            bool addMoreItems = true;
            while (addMoreItems)
            {
                Console.Write("Enter checklist item (or 'done' to finish): ");
                var item = Console.ReadLine();
                if (item.ToLower() == "done")
                {
                    addMoreItems = false;
                }
                else
                {
                    checklistTask.ChecklistItems.Add(item);
                }
            }
        }

        category.AddTask(task);
    }
}
