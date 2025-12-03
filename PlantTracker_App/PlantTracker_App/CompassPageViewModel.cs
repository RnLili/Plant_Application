using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Devices.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker_App
{
    public partial class CompassPageViewModel : ObservableObject
    {
        [ObservableProperty]
        double heading;

        public CompassPageViewModel()
        {
            Compass.ReadingChanged += Compass_ReadingChanged;  
        }

        private void Compass_ReadingChanged(object sender, CompassChangedEventArgs e)
        {            
            Heading = e.Reading.HeadingMagneticNorth;
        }

        [RelayCommand]
        void Start()
        {
            if (!Compass.IsSupported)
                return;

            if (!Compass.IsMonitoring)
                Compass.Start(SensorSpeed.UI);
        }

        [RelayCommand]
        void Stop()
        {
            if (Compass.IsMonitoring)
                Compass.Stop();
        }
    }
}
