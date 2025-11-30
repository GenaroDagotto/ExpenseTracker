using System;

namespace ExpenseTracker.Models;

public class Expense
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public string Category { get; set; }
    public DateTime Date { get; set; }

    public Expense()
    {
        Id = Guid.NewGuid();
        Date = DateTime.Now;
        Description = string.Empty;
        Category = string.Empty;
    }

    public Expense(string description, decimal amount, string category, DateTime date)
    {
        Id = Guid.NewGuid();
        Description = description;
        Amount = amount;
        Category = category;
        Date = date;
    }
}    
