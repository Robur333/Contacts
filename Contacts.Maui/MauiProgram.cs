using CommunityToolkit.Maui.Core;
using Contacts.Maui.Models;
using Contacts.Maui.Views;
using Microsoft.Extensions.Logging;

namespace Contacts.Maui
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
            builder.UseMauiApp<App>().UseMauiCommunityToolkitCore();

            builder.Services.AddSingleton<AddContactPage>();
            builder.Services.AddSingleton<EditContactPage>();
            builder.Services.AddSingleton<ContactsPage>();

            builder.Services.AddSingleton<ContactDatabase>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
