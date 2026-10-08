using System.Collections.ObjectModel;
using BusinessExpenseTracker.Models;

namespace BusinessExpenseTracker.Services;

public static class ExpenseStore
{
    private static int _nextId = 1;
    public static ObservableCollection<Expense> Expenses { get; } = new();

    public static Expense Add(string name, decimal amount, string category)
    {
        var expense = new Expense { Id = _nextId++, Name = name, Amount = amount, Category = category, Date = DateTime.Now };
        Expenses.Add(expense);
        return expense;
    }

    public static Expense? GetById(int id) => Expenses.FirstOrDefault(x => x.Id == id);
}
