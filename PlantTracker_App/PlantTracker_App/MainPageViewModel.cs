using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker_App
{
    public partial class MainPageViewModel : ObservableObject
    {
        private IPlantDatabase database;

        public ObservableCollection<Plant> Plants { get; set; }

        [ObservableProperty]
        private Plant selectedPlant;

        [ObservableProperty]
        private Plant editedPlant;
        public MainPageViewModel(IPlantDatabase database)
        {
            this.database = database;
            Plants = new ObservableCollection<Plant>();           
            
        }

        public async Task InitAsync()
        {
            var petList = await database.GetPlantsAsync();
            Plants.Clear();
            petList.ForEach(p => Plants.Add(p));
        }

        [RelayCommand]
        public async Task PlantDetails()
        {
            if (SelectedPlant != null)
            {
                var p = new ShellNavigationQueryParameters
                {
                    {"Plant", SelectedPlant }
                };
                await Shell.Current.GoToAsync("plantdetails", p);
            }
            else
            {
                WeakReferenceMessenger.Default.Send("Please select a plant.");
            }
        }
        [RelayCommand]
        public async Task NewPlant()
        {
            SelectedPlant = null;
            var param = new ShellNavigationQueryParameters
            {
                { "Plant", null}  //lehet probléma lesz
            };
            await Shell.Current.GoToAsync("editplant", param);
        }

        [RelayCommand]
        public async Task DeletePlant()
        {
            if(SelectedPlant != null )
            {
                database.DeletePlantAsync(SelectedPlant);
                Plants.Remove(SelectedPlant);
                SelectedPlant = null;
            }
            else
            {
                WeakReferenceMessenger.Default.Send("Please select a plant to delete.");
            }
        }

        [RelayCommand]
        public async Task EditPlant()
        {
            if (SelectedPlant != null)
            {
                var param = new ShellNavigationQueryParameters
            {
                { "Pet", SelectedPlant }
            };
                await Shell.Current.GoToAsync("editplant", param);
            }
            else
            {
                WeakReferenceMessenger.Default.Send("Select a plant to edit.");
            }
        }

    }
}
