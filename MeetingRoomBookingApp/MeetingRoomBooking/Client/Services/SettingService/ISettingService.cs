namespace MeetingRoomBooking.Client.Services.SettingService
{
    public interface ISettingService
    {
        List<Setting> Settings { get; set; }
        Task GetSettings();
    }
}
