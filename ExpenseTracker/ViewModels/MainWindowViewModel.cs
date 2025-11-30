using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ExpenseTracker.Models;
using ExpenseTracker.Services;
using ExpenseTracker.Data;

namespace ExpenseTracker.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly IExpenseService _expenseService;
    
    private string _description = string.Empty;
    private decimal _amount;
    private string _selectedCategory = "Food";
    private DateTime _selectedDate = DateTime.Now;
    private string _totalExpenses = "$0.00";
    
    public ObservableCollection<Expense> Expenses { get; }
    public ObservableCollection<string> Categories { get; }
    
    public string Description
    {
        get => _description;
        set
        {
            _description = value;
            OnPropertyChanged();
        }
    }
    
    public decimal Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            OnPropertyChanged();
        }
    }
    
    public string SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            _selectedCategory = value;
            OnPropertyChanged();
        }
    }
    
    public DateTime SelectedDate
    {
        get => _selectedDate;
        set
        {
            _selectedDate = value;
            OnPropertyChanged();
        }
    }
    
    public string TotalExpenses
    {
        get => _totalExpenses;
        set
        {
            _totalExpenses = value;
            OnPropertyChanged();
        }
    }
    
    public MainWindowViewModel()
    {
        _expenseService = new ExpenseService(new JsonStorageService());
        
        Expenses = new ObservableCollection<Expense>(_expenseService.GetAllExpenses());
        
        Categories = new ObservableCollection<string>
        {
            "Food",
            "Transport",
            "Entertainment",
            "Utilities",
            "Shopping",
            "Health",
            "Other"
        };
        
        UpdateTotal();
    }
    
    public void AddExpense()
    {
        if (string.IsNullOrWhiteSpace(Description) || Amount <= 0)
            return;
        
        var expense = new Expense(Description, Amount, SelectedCategory, SelectedDate);
        _expenseService.AddExpense(expense);
        
        Expenses.Insert(0, expense);
        UpdateTotal();
        
        // Clear form
        Description = string.Empty;
        Amount = 0;
        SelectedDate = DateTime.Now;
    }
    
    public void DeleteExpense(Expense expense)
    {
        _expenseService.RemoveExpense(expense.Id);
        Expenses.Remove(expense);
        UpdateTotal();
    }
    
    private void UpdateTotal()
    {
        var total = _expenseService.GetTotalExpenses();
        TotalExpenses = $"Total: ${total:F2}";
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}