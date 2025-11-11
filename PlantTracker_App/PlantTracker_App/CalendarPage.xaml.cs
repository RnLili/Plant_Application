using CommunityToolkit.Mvvm.Messaging;

namespace PlantTracker_App;

public partial class CalendarPage : ContentPage
{
    public CalendarPage(CalendarPageViewModel calendar_viewModel)
    {
        InitializeComponent();
        BindingContext = calendar_viewModel;
        WeakReferenceMessenger.Default.Register<string>(this, async (r, m) =>
        {
            await DisplayAlert("Warning", m, "OK");
        });
    }
}