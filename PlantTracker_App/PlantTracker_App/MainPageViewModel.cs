using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        }
        [RelayCommand]
        public async Task NewPlant()
        {
            SelectedPlant = null;
            var param = new ShellNavigationQueryParameters
        {
             { "Plant",  SelectedPlant}
        };
            await Shell.Current.GoToAsync("editpet", param);
        }
    }
}
