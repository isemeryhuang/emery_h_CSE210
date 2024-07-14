using System;
using System.Collections.Generic;

public class ToDoList
{
    // Attributes
    private List<Category> _categories;

    // Constructor
    public ToDoList()
    {
        _categories = new List<Category>();
    }

    // Properties
    public List<Category> Categories { get => _categories; set => _categories = value; }

    // Methods
    public void AddCategory(Category category)
    {
        Categories.Add(category);
    }

    public void RemoveCategory(Category category)
    {
        Categories.Remove(category);
    }

    public void DisplayCategories()
    {
        foreach (var category in Categories)
        {
            category.DisplayTasks();
        }
    }

    // Serialize method
    public string Serialize()
    {
        List<string> categoryData = new List<string>();
        foreach (var category in Categories)
        {
            categoryData.Add(category.Serialize());
        }
        return $"ToDoList|{string.Join(";", categoryData)}";
    }

    // Deserialize method
    public void Deserialize(string data)
    {
        var parts = data.Split('|');
        if (parts.Length < 2) return;

        var categoriesData = parts[1].Split(';');
        Categories = new List<Category>();
        foreach (var categoryData in categoriesData)
        {
            var category = new Category();
            category.Deserialize(categoryData.Split('|'));
            Categories.Add(category);
        }
    }
}
