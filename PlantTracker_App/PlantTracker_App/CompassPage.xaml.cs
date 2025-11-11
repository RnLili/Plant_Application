using CommunityToolkit.Mvvm.Messaging;

namespace PlantTracker_App;

public partial class CompassPage : ContentPage
{
    public CompassPage(CompassPageViewModel compass_viewModel)
    {
        InitializeComponent();
        BindingContext = compass_viewModel;
        WeakReferenceMessenger.Default.Register<string>(this, async (r, m) =>
        {
            await DisplayAlert("Warning", m, "OK");
        });
    }
}