global using System.Net.Http.Json;
global using MeetingRoomBooking.Shared;
global using Telerik.Blazor.Services;
global using MeetingRoomBooking.Client.Shared.Resources;
global using System.Globalization;
global using Blazored.LocalStorage;
global using Microsoft.AspNetCore.Components.Authorization;
using MeetingRoomBooking.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MeetingRoomBooking.Client.Services.BookingService;
using MeetingRoomBooking.Client.Services.RoomService;
using MeetingRoomBooking.Client.Services.UserService;
using MeetingRoomBooking.Client.Services.RoleService;
using MeetingRoomBooking.Client.Services.UserRoleService;
using MeetingRoomBooking.Client.Services.ImageRoomService;
using MeetingRoomBooking.Client.Services.SettingService;
using MeetingRoomBooking.Client.Services.AuthService;
using MeetingRoomBooking.Client.Services.Localizer;
using MeetingRoomBooking.Client.Extensions;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// localstorage for CultureChooser
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IImageRoomService, ImageRoomService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddTelerikBlazor();
// register a custom localizer for the Telerik components, after registering the Telerik services
builder.Services.AddSingleton(typeof(ITelerikStringLocalizer), typeof(ResxLocalizer));

// using host for culture changing
var host = builder.Build();
await host.SetDefaultCulture();
await host.RunAsync();
