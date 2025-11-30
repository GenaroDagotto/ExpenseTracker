using System.Collections.Generic;
using ExpenseTracker.Models;

namespace ExpenseTracker.Services;

public interface IStorageService
{
    void SaveExpenses(List<Expense> expenses);
    List<Expense> LoadExpenses();
}