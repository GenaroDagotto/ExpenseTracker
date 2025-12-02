# 💰 Expense Tracker

A desktop expense tracking application built with C# and Avalonia UI, implementing SOLID principles and design patterns.

## 📋 Project Overview

Expense Tracker is a cross-platform desktop application that allows users to track their daily expenses. The application features a clean, intuitive GUI for adding, viewing, and managing expenses across different categories. All data is persisted locally using JSON storage.

## ✨ Features

- **Add Expenses**: Create new expense entries with description, amount, category, and date
- **View Expenses**: Display all expenses in a scrollable list with detailed information
- **Delete Expenses**: Remove unwanted expense entries
- **Category Management**: Organize expenses into predefined categories (Food, Transport, Entertainment, etc.)
- **Total Calculation**: Real-time calculation and display of total expenses
- **Data Persistence**: Automatic saving and loading of expenses using JSON storage
- **Cross-Platform**: Runs on macOS, Windows, and Linux thanks to Avalonia UI

## 🏗️ File Structure
```
ExpenseTracker/
├── Models/
│   └── Expense.cs                    # Expense entity model
├── ViewModels/
│   ├── ViewModelBase.cs              # Base class for ViewModels
│   └── MainWindowViewModel.cs        # Main window ViewModel (MVVM pattern)
├── Views/
│   ├── MainWindow.axaml              # Main window UI (XAML)
│   └── MainWindow.axaml.cs           # Main window code-behind
├── Services/
│   ├── IExpenseService.cs            # Expense service interface
│   ├── ExpenseService.cs             # Expense business logic implementation
│   └── IStorageService.cs            # Storage service interface
├── Data/
│   └── JsonStorageService.cs         # JSON storage implementation
├── Assets/
│   └── avalonia-logo.ico             # Application icon
├── App.axaml                          # Application-level XAML
├── Program.cs                         # Application entry point
└── README.md                          # This file

ExpenseTracker.Tests/
└── UnitTest1.cs                       # Unit tests for ExpenseService
```

## 🔧 Installation Instructions

### Prerequisites
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) or later
- [JetBrains Rider](https://www.jetbrains.com/rider/) or Visual Studio 2022

### Steps

1. **Clone the repository**
```bash
   git clone https://github.com/GenaroDagotto/ExpenseTracker.git
   cd ExpenseTracker
```

2. **Restore dependencies**
```bash
   dotnet restore
```

3. **Build the project**
```bash
   dotnet build
```

4. **Run the application**
```bash
   dotnet run --project ExpenseTracker
```

### Running Tests
```bash
dotnet test
```

## 🔌 API Usage Details

### ExpenseService API

The `IExpenseService` interface provides the following methods:
```csharp
// Add a new expense
void AddExpense(Expense expense);

// Remove an expense by ID
void RemoveExpense(Guid id);

// Get all expenses (ordered by date descending)
List<Expense> GetAllExpenses();

// Get expenses filtered by category
List<Expense> GetExpensesByCategory(string category);

// Calculate total for a specific category
decimal GetTotalByCategory(string category);

// Calculate total of all expenses
decimal GetTotalExpenses();

// Get list of all unique categories
List<string> GetCategories();
```

### Storage Service API

The `IStorageService` interface provides:
```csharp
// Save expenses to persistent storage
void SaveExpenses(List<Expense> expenses);

// Load expenses from persistent storage
List<Expense> LoadExpenses();
```

## 💾 Data Storage

### Storage Location
Data is stored in a JSON file located at:
- **macOS**: `~/Library/Application Support/ExpenseTracker/expenses.json`
- **Windows**: `%APPDATA%\ExpenseTracker\expenses.json`
- **Linux**: `~/.config/ExpenseTracker/expenses.json`

### Data Format
Expenses are stored in JSON format:
```json
[
  {
    "Id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
    "Description": "Grocery shopping",
    "Amount": 45.50,
    "Category": "Food",
    "Date": "2025-11-29T10:30:00"
  }
]
```

## ⚠️ Known Issues/Limitations

- **Date Picker**: On some systems, the DatePicker may have timezone conversion issues. The application defaults to the current system date.
- **No Export Feature**: Currently, there's no way to export expenses to CSV or Excel.
- **No Budget Tracking**: The app doesn't include budget limits or warnings.
- **Single User**: The application is designed for single-user local use only.
- **No Categories Customization**: Categories are hardcoded and cannot be customized by users.

## 🐛 Debugging Summary

### Common Issues Encountered During Development

1. **ReactiveUI Dependency Issues**n    - **Problem**: Initial implementation used ReactiveCommand which required additional dependencies
    - **Solution**: Simplified to use INotifyPropertyChanged and standard event handlers

2. **DatePicker Binding**n    - **Problem**: DateTimeOffset conversion errors with certain date formats
    - **Solution**: Used nullable DateTime and proper binding modes

3. **Storage Path**n    - **Problem**: Permission denied errors when writing to certain directories
    - **Solution**: Used Environment.SpecialFolder.ApplicationData for cross-platform compatibility

### Testing Approach

- Unit tests verify core business logic in ExpenseService
- Manual testing performed for UI interactions
- Data persistence tested by closing and reopening the application

## 🎯 SOLID Principles Implementation

### Single Responsibility Principle (SRP)
- `Expense`: Represents expense data only
- `ExpenseService`: Handles expense business logic
- `JsonStorageService`: Manages data persistence
- `MainWindowViewModel`: Handles UI state and user interactions

### Open/Closed Principle (OCP)
- `IExpenseService` and `IStorageService` interfaces allow for extension without modification
- New storage mechanisms can be added by implementing `IStorageService`

### Liskov Substitution Principle (LSP)
- Any implementation of `IStorageService` can replace `JsonStorageService` without breaking functionality

### Interface Segregation Principle (ISP)
- Small, focused interfaces (`IExpenseService`, `IStorageService`)
- Clients only depend on methods they actually use

### Dependency Inversion Principle (DIP)
- `ExpenseService` depends on `IStorageService` abstraction, not concrete implementation
- High-level modules don't depend on low-level modules

## 🎨 Design Pattern: Repository Pattern

The application implements the **Repository Pattern** through the `ExpenseService` class, which:
- Abstracts data access logic
- Provides a collection-like interface for accessing domain objects
- Centralizes data access logic
- Makes testing easier by allowing mock implementations

## 📝 Credits and Acknowledgements

- **Framework**: [Avalonia UI](https://avaloniaui.net/) - Cross-platform XAML-based UI framework
- **Language**: C# with .NET 8.0
- **Testing**: xUnit testing framework
- **IDE**: JetBrains Rider
- **Version Control**: Git & GitHub
- **Developer**: Genaro Dagotto
- **Course**: Software Engineering 2
- **Year**: 2025

## 📄 License

This project is created for educational purposes as part of a Software Engineering 2 course assignment.
