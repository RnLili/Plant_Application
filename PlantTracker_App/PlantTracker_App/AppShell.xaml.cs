namespace PlantTracker_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("plantdetails", typeof(PlantDetailsPage));
            Routing.RegisterRoute("editplant", typeof(EditPlantPage));
        }
    }
}
