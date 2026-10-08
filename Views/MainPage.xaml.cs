using BusinessExpenseTracker.Contracts;
using BusinessExpenseTracker.ViewModels;

namespace BusinessExpenseTracker.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainViewModel();
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
