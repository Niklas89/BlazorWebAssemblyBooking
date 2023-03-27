namespace MeetingRoomBooking.Server.Services.SettingService
{
    public interface ISettingService
    {
        Task<ServiceResponse<List<Setting>>> GetSettings();
    }
}
