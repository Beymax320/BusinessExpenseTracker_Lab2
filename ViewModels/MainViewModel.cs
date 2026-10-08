using System.Collections.ObjectModel;
using System.Diagnostics;
using BusinessExpenseTracker.Contracts;
using BusinessExpenseTracker.Models;
using BusinessExpenseTracker.Services;
using BusinessExpenseTracker.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;

namespace BusinessExpenseTracker.ViewModels;

public partial class MainViewModel : ObservableObject, ILifecycleAware
{
    private const string DraftNameKey = "draft_expense_name";
    private const string DraftAmountKey = "draft_expense_amount";
    private const string DraftCategoryKey = "draft_expense_category";

    [ObservableProperty] private string expenseName = string.Empty;
    [ObservableProperty] private string amount = string.Empty;
    [ObservableProperty] private string category = string.Empty;
    [ObservableProperty] private Expense? selectedExpense;

    public ObservableCollection<Expense> Expenses => ExpenseStore.Expenses;

    public MainViewModel() => RestoreDraft();

    [RelayCommand]
    private void AddExpense()
    {
        if (string.IsNullOrWhiteSpace(ExpenseName) || string.IsNullOrWhiteSpace(Category) ||
            !decimal.TryParse(Amount, out var value) || value <= 0) return;

        ExpenseStore.Add(ExpenseName.Trim(), value, Category.Trim());
        ExpenseName = Amount = Category = string.Empty;
        SaveDraft();
    }

    [RelayCommand]
    private async Task OpenExpense(Expense? expense)
    {
        if (expense is null) return;
        SelectedExpense = null;
        await Shell.Current.GoToAsync($"{nameof(ExpenseDetailPage)}?id={expense.Id}");
    }

    public void OnAppearing()
    {
        Debug.WriteLine("[VM] MainViewModel.OnAppearing");
        RestoreDraft();
    }

    public void OnDisappearing()
    {
        Debug.WriteLine("[VM] MainViewModel.OnDisappearing");
        SaveDraft();
    }

    private void SaveDraft()
    {
        Preferences.Set(DraftNameKey, ExpenseName ?? string.Empty);
        Preferences.Set(DraftAmountKey, Amount ?? string.Empty);
        Preferences.Set(DraftCategoryKey, Category ?? string.Empty);
    }

    private void RestoreDraft()
    {
        ExpenseName = Preferences.Get(DraftNameKey, string.Empty);
        Amount = Preferences.Get(DraftAmountKey, string.Empty);
        Category = Preferences.Get(DraftCategoryKey, string.Empty);
    }
}
