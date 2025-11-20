using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantTracker_App;

namespace PlantTracker_App
{
    [QueryProperty(nameof(EditedPlant), "Plant")]
    public partial class EditPlantPageViewModel : ObservableObject
    {
        [ObservableProperty]
        Plant editedPlant;

        [ObservableProperty]
        Plant draft;

        public Array WaterNeeds { get; } = Enum.GetValues<WaterType>(); 
        public Array LightNeeds { get; } = Enum.GetValues<LightType>();
        public Array Fertilizer { get; } = Enum.GetValues<FertilizerType>();

        public void InitDraft()
        {
            Draft = EditedPlant.GetCopy();
        }
        
        [RelayCommand]
        public async Task SavePlant()
        {
            var p = new ShellNavigationQueryParameters
        {
            { "EditedPlant", Draft }
        };
            await Shell.Current.GoToAsync("..", p);
        }

        [RelayCommand]
        public async Task CancelEdit()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
