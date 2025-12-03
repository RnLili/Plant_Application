using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlantTracker_App
{

    public partial class CalendarPageViewModel : ObservableObject
    {
        public IEventDatabase db { get; set; }

        [ObservableProperty]
        DateTime selectedDate = DateTime.Today;

        [ObservableProperty]
        ObservableCollection<CalendarEvent> events;

        public CalendarPageViewModel(IEventDatabase db)
        {
            this.db = db;
            events = new ObservableCollection<CalendarEvent>();
            LoadEventsForDate();
        }
        public async void LoadEventsForDate()
        {
            var list = await db.GetEventsByDateAsync(SelectedDate);

            Events = new ObservableCollection<CalendarEvent>(list);
        }
        [RelayCommand]
        public async Task AddEvent()
        {
            string title = await PageExtensions.CurrentPage.DisplayPromptAsync(
        "New Event", "Event title:");

            if (string.IsNullOrWhiteSpace(title))
                return;

            var newEvent = new CalendarEvent
            {
                Date = SelectedDate,
                Title = title
            };

            await db.AddEventAsync(newEvent);
            LoadEventsForDate();
        }
        [RelayCommand]
        public async Task DeleteEvent(CalendarEvent evt)
        {
            bool confirm = await PageExtensions.CurrentPage.DisplayAlert("Delete Event", $"Delete '{evt.Title}'?", "Yes", "No");

            if (!confirm) return;

            await db.DeleteEventAsync(evt);
            LoadEventsForDate();
        }
        
        partial void OnSelectedDateChanged(DateTime value)
        {
            LoadEventsForDate();
        }

    }
    public static class PageExtensions
    {
        public static Page CurrentPage =>
            App.Current?.Windows.FirstOrDefault()?.Page
            ?? throw new Exception("No active window found.");
    }

}

