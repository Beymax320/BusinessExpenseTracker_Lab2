using BusinessExpenseTracker.Views;

namespace BusinessExpenseTracker;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ExpenseDetailPage), typeof(ExpenseDetailPage));
    }
}
