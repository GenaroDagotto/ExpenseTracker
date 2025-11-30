using Avalonia.Controls;
using Avalonia.Interactivity;
using ExpenseTracker.Models;
using ExpenseTracker.ViewModels;

namespace ExpenseTracker.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }

    private void AddExpenseButton_Click(object? sender, RoutedEventArgs e)
    {
        if (DataContext is MainWindowViewModel viewModel)
        {
            viewModel.AddExpense();
        }
    }

    private void DeleteButton_Click(object? sender, RoutedEventArgs e)
    {
        if (sender is Button button && button.Tag is Expense expense)
        {
            if (DataContext is MainWindowViewModel viewModel)
            {
                viewModel.DeleteExpense(expense);
            }
        }
    }
}