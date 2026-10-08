using System.Diagnostics;
using BusinessExpenseTracker.Contracts;
using BusinessExpenseTracker.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

namespace BusinessExpenseTracker.ViewModels;

public partial class ExpenseDetailViewModel : ObservableObject, IQueryAttributable, ILifecycleAware
{
    [ObservableProperty] private int expenseId;
    [ObservableProperty] private string name = string.Empty;
    [ObservableProperty] private string amount = string.Empty;
    [ObservableProperty] private string category = string.Empty;
    [ObservableProperty] private string dateText = string.Empty;

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (!query.TryGetValue("id", out var raw) || !int.TryParse(raw?.ToString(), out var id)) return;
        ExpenseId = id;
        Preferences.Set("last_expense_id", id);
        LoadExpense();
    }

    private void LoadExpense()
    {
        var expense = ExpenseStore.GetById(ExpenseId);
        if (expense is null) return;
        Name = expense.Name;
        Amount = expense.Amount.ToString("F2");
        Category = expense.Category;
        DateText = expense.Date.ToString("dd.MM.yyyy HH:mm");
    }

    [RelayCommand]
    private async Task Save()
    {
        var expense = ExpenseStore.GetById(ExpenseId);
        if (expense is null || !decimal.TryParse(Amount, out var value) || value <= 0) return;
        expense.Name = Name.Trim();
        expense.Amount = value;
        expense.Category = Category.Trim();
        await Shell.Current.GoToAsync("..");
    }

    public void OnAppearing() => Debug.WriteLine($"[VM] Detail.OnAppearing id={ExpenseId}");
    public void OnDisappearing() => Debug.WriteLine($"[VM] Detail.OnDisappearing id={ExpenseId}");
}
