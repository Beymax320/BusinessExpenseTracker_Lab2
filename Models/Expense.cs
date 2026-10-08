
using CommunityToolkit.Mvvm.ComponentModel;

namespace BusinessExpenseTracker.Models;

public partial class Expense : ObservableObject
{
    [ObservableProperty]
    private int id;

    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private decimal amount;

    [ObservableProperty]
    private string category = string.Empty;

    [ObservableProperty]
    private DateTime date = DateTime.Now;
}
