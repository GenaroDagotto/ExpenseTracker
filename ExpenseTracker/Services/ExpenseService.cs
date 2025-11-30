using System;
using System.Collections.Generic;
using System.Linq;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public class ExpenseService : IExpenseService
{
    private readonly List<Expense> _expenses;
    private readonly IStorageService _storageService;

    public ExpenseService(IStorageService storageService)
    {
        _storageService = storageService;
        _expenses = _storageService.LoadExpenses();
    }

    public void AddExpense(Expense expense)
    {
        _expenses.Add(expense);
        _storageService.SaveExpenses(_expenses);
    }

    public void RemoveExpense(Guid id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense != null)
        {
            _expenses.Remove(expense);
            _storageService.SaveExpenses(_expenses);
        }
    }

    public List<Expense> GetAllExpenses()
    {
        return _expenses.OrderByDescending(e => e.Date).ToList();
    }

    public List<Expense> GetExpensesByCategory(string category)
    {
        return _expenses.Where(e => e.Category == category)
            .OrderByDescending(e => e.Date)
            .ToList();
    }

    public decimal GetTotalByCategory(string category)
    {
        return _expenses.Where(e => e.Category == category)
            .Sum(e => e.Amount);
    }

    public decimal GetTotalExpenses()
    {
        return _expenses.Sum(e => e.Amount);
    }

    public List<string> GetCategories()
    {
        return _expenses.Select(e => e.Category)
            .Distinct()
            .OrderBy(c => c)
            .ToList();
    }
}