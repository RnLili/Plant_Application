using CommunityToolkit.Mvvm.Messaging;

namespace PlantTracker_App;

public partial class NewPlantPage : ContentPage
{	
    public NewPlantPageViewModel new_viewmodel;
	public NewPlantPage(NewPlantPageViewModel new_viewmodel)
	{
		InitializeComponent();
        this.new_viewmodel = new_viewmodel;		
		BindingContext = new_viewmodel;
        WeakReferenceMessenger.Default.Register<string>(this, async (r, m) =>
        {
            await DisplayAlert("Warning", m, "OK");
        });
    }
    
    
}