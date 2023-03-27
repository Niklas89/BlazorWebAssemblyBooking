using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace MeetingRoomBooking.Client.Extensions
{
    public static class WebAssemblyHostExtension
    {
        // get culture from localstorage and assign it to our culture
        public async static Task SetDefaultCulture(this WebAssemblyHost host)
        {
            // we can't inject LocalStorage directly, but we can use host to fetch the localstorage
            var localStorage = host.Services.GetRequiredService<ILocalStorageService>();

            // retrieve culture from that localstorage
            var cultureFromLS = await localStorage.GetItemAsync<string>("culture");

            CultureInfo culture;

            if (cultureFromLS != null)
            {
                culture = new CultureInfo(cultureFromLS);
            }
            else // if culture in localstorage is null we'll set it to our default culture
            {
                culture = new CultureInfo("en-US");
            }

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }
    }
}