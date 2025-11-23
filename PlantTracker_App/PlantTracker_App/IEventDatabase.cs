using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantTracker_App
{
    public interface IEventDatabase
    {
        Task<List<CalendarEvent>> GetEventsAsync();
        Task<List<CalendarEvent>> GetEventsByDateAsync(DateTime date);
        Task<int> AddEventAsync(CalendarEvent evt);
        Task<int> DeleteEventAsync(CalendarEvent evt);
    }
}
