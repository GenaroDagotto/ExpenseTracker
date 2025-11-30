using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.Data;

public class JsonStorageService : IStorageService
{
    private readonly string _filePath;

    public JsonStorageService()
    {
        var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var appFolder = Path.Combine(appDataPath, "ExpenseTracker");
        
        if (!Directory.Exists(appFolder))
        {
            Directory.CreateDirectory(appFolder);
        }
        
        _filePath = Path.Combine(appFolder, "expenses.json");
    }

    public void SaveExpenses(List<Expense> expenses)
    {
        var json = JsonSerializer.Serialize(expenses, new JsonSerializerOptions 
        { 
            WriteIndented = true 
        });
        File.WriteAllText(_filePath, json);
    }

    public List<Expense> LoadExpenses()
    {
        if (!File.Exists(_filePath))
        {
            return new List<Expense>();
        }

        var json = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
    }
}