using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PlantTracker_App
{
    public class SQLitePlantDatabase : IPlantDatabase
    {
        SQLite.SQLiteOpenFlags Flags =
       SQLite.SQLiteOpenFlags.ReadWrite |
       SQLite.SQLiteOpenFlags.Create;

        string databasePath =
            Path.Combine(FileSystem.Current.AppDataDirectory, "plants.db3");

        SQLiteAsyncConnection database;

        public SQLitePlantDatabase()
        {
            database = new SQLiteAsyncConnection(databasePath, Flags);
            database.CreateTableAsync<Plant>().Wait();
            SeedAsync().Wait();
        }
        private async Task SeedAsync()
        {
            if (await database.Table<Plant>().CountAsync() == 0)
            {
                var plants = new List<Plant>
                {
                    new Plant { Name = "Kaktusz", Description = "Szúr", WaterNeed = WaterType.Low, LightNeed = LightType.High, Fertilzer = FertilzerType.Succulent },
                    new Plant { Name = "Orchidea", Description = "Párás környezet", WaterNeed = WaterType.Medium, LightNeed = LightType.Medium, Fertilzer = FertilzerType.Orchid },
                   // new Plant { Name = "Lila madársóska", Description = "Gumós", WaterNeed = WaterType.Medium, LightNeed = LightType.Medium, Fertilzer = FertilzerType.Flower },
                    //new Plant { Name = "Korall Virág", Description = "Alulról öntözés", WaterNeed = WaterType.Medium, LightNeed = LightType.High, Fertilzer = FertilzerType.Succulent },
                    //new Plant { Name = "Ciklámen", Description = "Drámai, ha nem kap vizet", WaterNeed = WaterType.High, LightNeed = LightType.Medium, Fertilzer = FertilzerType.Flower },

                };
            }
        }

        public async Task CreatePlantAsync(Plant plant)
        {
            await database.InsertAsync(plant);
        }

        public async Task DeletePlantAsync(Plant plant)
        {
            await database.DeleteAsync(plant);
        }

        public async Task<Plant> GetPlantAsync(int id)
        {
            return await database.Table<Plant>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Plant>> GetPlantsAsync()
        {
            return await database.Table<Plant>().ToListAsync();
        }

        public async Task UpdatePlantAsync(Plant plant)
        {
            await database.UpdateAsync(plant);
        }
    }
}
