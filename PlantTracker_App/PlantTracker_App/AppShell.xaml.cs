namespace PlantTracker_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("editplant", typeof(EditPlantPage));
            Routing.RegisterRoute("newplant", typeof(NewPlantPage));
        }
    }
}
