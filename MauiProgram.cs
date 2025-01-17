﻿using DayPlanner.Data;
using DayPlanner.Services;
using DayPlanner.ViewModels;
using DayPlanner.Views;
using Microsoft.Extensions.Logging;

namespace DayPlanner
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //Services
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "notes.db3");
            builder.Services.AddSingleton<INoteRepository, NoteRepository>(s => new NoteRepository(dbPath));

            //Navigation
            builder.Services.AddSingleton<INavigationService, NavigationService>();

            // Views
            builder.Services.AddTransient<NoteListPage>();
            builder.Services.AddTransient<NoteEditPage>();

            //ViewModels
            builder.Services.AddTransient<NoteListVM>();
            builder.Services.AddTransient<NoteEditVM>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
