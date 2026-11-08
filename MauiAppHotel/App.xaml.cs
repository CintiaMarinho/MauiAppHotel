
using Microsoft.Maui.Controls;

namespace MauiAppHotel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(
        IActivationState? activationState)
    {
        var window = new Window(new AppShell());

        window.Height = 700;
        window.Width = 350;

        return window;
    }
}
