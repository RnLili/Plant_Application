using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker_App
{
    public class SQLiteEventDatabase : IEventDatabase
    {
        SQLite.SQLiteOpenFlags Flags =
      SQLite.SQLiteOpenFlags.ReadWrite |
      SQLite.SQLiteOpenFlags.Create;

        string databasePath =
            Path.Combine(FileSystem.Current.AppDataDirectory, "events.db3");

        SQLiteAsyncConnection database;

        public SQLiteEventDatabase()
        {
            database = new SQLiteAsyncConnection(databasePath, Flags);
            database.CreateTableAsync<CalendarEvent>().Wait();
            
        }

        public Task<int> AddEventAsync(CalendarEvent evt)
        {
            return database.InsertAsync(evt);
        }

        public Task<int> DeleteEventAsync(CalendarEvent evt)
        {
            return database.DeleteAsync(evt);
        }

        public Task<List<CalendarEvent>> GetEventsAsync()
        {
            return database.Table<CalendarEvent>().ToListAsync();
        }

        public Task<List<CalendarEvent>> GetEventsByDateAsync(DateTime date)
        {
            return database.Table<CalendarEvent>().Where(e => e.Date == date.Date).ToListAsync();
        }
    }
}
