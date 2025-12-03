using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlantTracker_App
{
    [QueryProperty(nameof(NewPlant), "newplant")]
    
    public partial class MainPageViewModel : ObservableObject
    {
        string path = Path.Combine(FileSystem.Current.AppDataDirectory, "plants.json");
        public Plant NewPlant
        {
            set { Plants.Add(value); }
        }
        public ObservableCollection<Plant> Plants { get; set; }

        [ObservableProperty]
        private Plant selectedPlant;

        [ObservableProperty]
        private Plant editedPlant;
        public MainPageViewModel()
        {            
            Plants = new ObservableCollection<Plant>();      
        }

        public async Task LoadFromJson()
        {
            if (File.Exists(path) && Plants.Count == 0)
            {
                string jsonstring = await File.ReadAllTextAsync(path);
                List<Plant> jsonData = JsonSerializer.Deserialize<List<Plant>>(jsonstring);
                jsonData.ForEach(item => Plants.Add(item));

            }
        }


        public async Task SaveToJson()
        {
            string jsonstring = JsonSerializer.Serialize(Plants);
            await File.WriteAllTextAsync(path, jsonstring);
        }       


        [RelayCommand]
        public async Task AddPlant()
        {
            await Shell.Current.GoToAsync("newplant");
        }

        [RelayCommand]
        public async Task DeletePlant()
        {
            if(SelectedPlant != null )
            {                
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
                { "Plant", SelectedPlant }
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
