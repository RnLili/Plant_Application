using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public enum FertilizerType
    {
        Flower,
        Succulent,
        Orchid
    }
    public partial class Plant : ObservableObject
    {
        [ObservableProperty]
        [property:PrimaryKey]
        [property:AutoIncrement]
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
        FertilizerType fertilizer;
        //[ObservableProperty]
        //Image img;
        [ObservableProperty]
        bool isExpanded;

        public Plant GetCopy()
        {
            return (Plant)this.MemberwiseClone();
        }
    }
}
