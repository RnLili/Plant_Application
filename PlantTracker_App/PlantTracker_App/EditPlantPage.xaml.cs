using CommunityToolkit.Mvvm.Messaging;

namespace PlantTracker_App;

public partial class EditPlantPage : ContentPage
{
    private EditPlantPageViewModel EVM;
       
    public EditPlantPage(EditPlantPageViewModel EVM)
	{
		InitializeComponent();
        this.EVM = EVM;
        BindingContext = EVM;
        WeakReferenceMessenger.Default.Register<string>(this, async (r, m) =>
        {
            await DisplayAlert("Warning", m, "OK");
        });
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        EVM.InitDraft();
    }

   
}