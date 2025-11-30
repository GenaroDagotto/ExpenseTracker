using ExpenseTracker.Models;
using ExpenseTracker.Services;
using ExpenseTracker.Data;

namespace ExpenseTracker.Tests;

public class ExpenseServiceTests
{
    private IExpenseService CreateExpenseService()
    {
        // Usamos el JsonStorageService real, pero podríamos crear un mock
        var storageService = new JsonStorageService();
        return new ExpenseService(storageService);
    }

    [Fact]
    public void AddExpense_ShouldIncreaseExpenseCount()
    {
        // Arrange
        var service = CreateExpenseService();
        var initialCount = service.GetAllExpenses().Count;
        var expense = new Expense("Test Expense", 50.00m, "Food", DateTime.Now);

        // Act
        service.AddExpense(expense);
        var newCount = service.GetAllExpenses().Count;

        // Assert
        Assert.Equal(initialCount + 1, newCount);
    }

    [Fact]
    public void RemoveExpense_ShouldDecreaseExpenseCount()
    {
        // Arrange
        var service = CreateExpenseService();
        var expense = new Expense("Test Expense to Remove", 30.00m, "Transport", DateTime.Now);
        service.AddExpense(expense);
        var countAfterAdd = service.GetAllExpenses().Count;

        // Act
        service.RemoveExpense(expense.Id);
        var countAfterRemove = service.GetAllExpenses().Count;

        // Assert
        Assert.Equal(countAfterAdd - 1, countAfterRemove);
    }

    [Fact]
    public void GetTotalExpenses_ShouldReturnCorrectSum()
    {
        // Arrange
        var service = CreateExpenseService();
        var expense1 = new Expense("Expense 1", 100.00m, "Food", DateTime.Now);
        var expense2 = new Expense("Expense 2", 50.00m, "Food", DateTime.Now);

        // Act
        service.AddExpense(expense1);
        service.AddExpense(expense2);
        var total = service.GetTotalExpenses();

        // Assert
        Assert.True(total >= 150.00m); // >= porque puede haber datos previos
    }

    [Fact]
    public void GetExpensesByCategory_ShouldReturnOnlyMatchingCategory()
    {
        // Arrange
        var service = CreateExpenseService();
        var foodExpense = new Expense("Groceries", 80.00m, "Food", DateTime.Now);
        var transportExpense = new Expense("Bus", 20.00m, "Transport", DateTime.Now);

        // Act
        service.AddExpense(foodExpense);
        service.AddExpense(transportExpense);
        var foodExpenses = service.GetExpensesByCategory("Food");

        // Assert
        Assert.Contains(foodExpenses, e => e.Id == foodExpense.Id);
        Assert.DoesNotContain(foodExpenses, e => e.Id == transportExpense.Id);
    }
}