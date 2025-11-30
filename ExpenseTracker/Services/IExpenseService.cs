using System;
using System.Collections.Generic;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public interface IExpenseService
{
    void AddExpense(Expense expense);
    void RemoveExpense(Guid id);
    List<Expense> GetAllExpenses();
    List<Expense> GetExpensesByCategory(string category);
    decimal GetTotalByCategory(string category);
    decimal GetTotalExpenses();
    List<string> GetCategories();
}