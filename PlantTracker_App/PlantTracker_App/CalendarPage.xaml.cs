using CommunityToolkit.Mvvm.Messaging;

namespace PlantTracker_App;

public partial class CalendarPage : ContentPage
{
    public CalendarPageViewModel c_viewModel { get; set; }
    public CalendarPage(CalendarPageViewModel c_viewModel)
    {
        InitializeComponent();
        this.c_viewModel = c_viewModel;
        BindingContext = c_viewModel;
        WeakReferenceMessenger.Default.Register<string>(this, async (r, m) =>
        {
            await DisplayAlert("Warning", m, "OK");
        });
    }
}