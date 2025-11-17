namespace PlantTracker_App;
[QueryProperty(nameof(Plant), "Plant")]
public partial class EditPlantPage : ContentPage
{
    Plant plant;
    public Plant Plant
    {
        get => plant;
        set
        {
            plant = value;
            OnPropertyChanged();
        }
    }
    
    public EditPlantPage()
	{
		InitializeComponent();
        BindingContext = this;
    }
}