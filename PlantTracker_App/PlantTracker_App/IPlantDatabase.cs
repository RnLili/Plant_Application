using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker_App
{
    public interface IPlantDatabase
    {
        Task<List<Plant>> GetPlantsAsync();
        Task<Plant> GetPlantAsync(int id);
        Task CreatePlantAsync(Plant plant);
        Task UpdatePlantAsync(Plant plant);
        Task DeletePlantAsync(Plant plant);
    }
}
