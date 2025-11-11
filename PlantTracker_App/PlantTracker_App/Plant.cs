using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PlantTracker_App
{
    public enum WaterType
    {
        Low,
        Medium,
        High
    }
    public enum LightType
    {
        Low,
        Medium,
        High
    }
    public enum FertilzerType
    {
        Flower,
        Succulent,
        Orchid
    }
    public partial class Plant : ObservableObject
    {
        [ObservableProperty]
        int id;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string description;
        [ObservableProperty]
        WaterType waterNeed;
        [ObservableProperty]
        LightType lightNeed;
        [ObservableProperty]
        FertilzerType fertilzer;
        //[ObservableProperty]
        //Image img;
    }
}
