
namespace PlantTracker_App;
[QueryProperty(nameof(Plant), "Plant")]
public partial class PlantDetailsPage : ContentPage
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
    public PlantDetailsPage()
	{
		InitializeComponent();
        BindingContext = this;
	}
}