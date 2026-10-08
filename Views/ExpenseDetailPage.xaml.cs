using BusinessExpenseTracker.Contracts;
using BusinessExpenseTracker.ViewModels;

namespace BusinessExpenseTracker.Views;

public partial class ExpenseDetailPage : ContentPage
{
    public ExpenseDetailPage()
    {
        InitializeComponent();
        BindingContext = new ExpenseDetailViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as ILifecycleAware)?.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        (BindingContext as ILifecycleAware)?.OnDisappearing();
        base.OnDisappearing();
    }
}
