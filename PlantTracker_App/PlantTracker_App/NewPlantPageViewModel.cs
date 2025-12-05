using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker_App
{
    public partial class NewPlantPageViewModel : ObservableObject
    {
        public Array WaterNeeds { get; } = Enum.GetValues<WaterType>();
        public Array LightNeeds { get; } = Enum.GetValues<LightType>();
        public Array Fertilizer { get; } = Enum.GetValues<FertilizerType>();

        public Plant NewPlant { get; set; }

        public NewPlantPageViewModel()
        {
            NewPlant = new Plant();            
        }

        [RelayCommand]
        public async Task SavePlantButton()
        {

            var param = new ShellNavigationQueryParameters()
            {
                {"newplant",NewPlant}
            };
            await Shell.Current.GoToAsync("..", param);
        }
        [RelayCommand]
        public async Task CancelPlantButton()
        {
            await Shell.Current.GoToAsync("..");
        }
        [RelayCommand]
        public async Task ImageButton()
        {
            FileResult? photo = await MediaPicker.Default.PickPhotoAsync();

            if (photo != null)
            {
                string path = Path.Combine(FileSystem.Current.AppDataDirectory, photo.FileName);
                if (!File.Exists(path))
                {
                    using Stream source = await photo.OpenReadAsync();
                    using FileStream stream = File.OpenWrite(path);
                    await source.CopyToAsync(stream);
                }
                NewPlant.Url = path;
            }

        }

    }
}
