using CommunityToolkit.Mvvm.Messaging;

namespace PlantTracker_App;

public partial class CompassPage : ContentPage
{
    public CompassPageViewModel compass_viewModel;
    public CompassPage(CompassPageViewModel compass_viewModel)
    {
        InitializeComponent();
        this.compass_viewModel = compass_viewModel;
        BindingContext = compass_viewModel;
        WeakReferenceMessenger.Default.Register<string>(this, async (r, m) =>
        {
            await DisplayAlert("Warning", m, "OK");
        });
    }
}