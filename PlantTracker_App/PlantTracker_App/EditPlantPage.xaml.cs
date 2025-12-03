namespace PlantTracker_App;

public partial class EditPlantPage : ContentPage
{
    private EditPlantPageViewModel EVM;
       
    public EditPlantPage(EditPlantPageViewModel EVM)
	{
		InitializeComponent();
        this.EVM = EVM;
        BindingContext = EVM;
    }
    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        EVM.InitDraft();
    }

   
}