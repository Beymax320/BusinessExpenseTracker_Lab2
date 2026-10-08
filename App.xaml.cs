using System.Diagnostics;

namespace BusinessExpenseTracker;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        Debug.WriteLine("[APP] CreateWindow");
        var window = new Window(new AppShell());
        window.Created += (_, _) => Debug.WriteLine("[APP] OnStart / Created");
        window.Stopped += (_, _) => Debug.WriteLine("[APP] OnSleep / Stopped");
        window.Resumed += (_, _) => Debug.WriteLine("[APP] OnResume / Resumed");
        return window;
    }
}
