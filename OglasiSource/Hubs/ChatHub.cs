using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace OglasiSource.Api.Hubs
{
    [Authorize(AuthenticationSchemes = "ApiKey, Bearer")]
    public class ChatHub : Hub
    {
        //private readonly IReadGenericRepository<Core.Entities.GpsDevice> _gpsDevicesRepo;
        //private readonly IMapper _mapper;
        //private readonly ILiveTrackingHelper _liveTrackingHelper;

        //public TrainHub(IMapper mapper, IReadGenericRepository<GpsDevice> gpsDevicesRepo, ILiveTrackingHelper liveTrackingHelper)
        //{
        //    _mapper = mapper;
        //    _gpsDevicesRepo = gpsDevicesRepo;
        //    _liveTrackingHelper = liveTrackingHelper;
        //}
        //public static Dictionary<string, int> _currentUsers = new Dictionary<string, int>();
        //public async Task SendGpsDataAsync(string? deviceId)
        //{
        //    var data = await _gpsDevicesRepo.GetFirstAsync(x => x.DeviceId == deviceId, x => new LiveTrackingSignalItemResponse()
        //    {
        //        Altitude = x.GpsData.Altitude,
        //        DeviceId = deviceId,
        //        Heading = x.GpsData!.Heading,
        //        Latitude = x.GpsData.Latitude,
        //        Longitude = x.GpsData.Longitude,
        //        Speed = x.GpsData.Speed,
        //        CompanyId = x.CompanyId,
        //        MotionStatus = x.GpsData.Status.HasValue ? (int)x.GpsData.Status.Value : null,
        //        UnitType = x.UnitType.HasValue ? (int)x.UnitType.Value : null,
        //    });

        //    data.HeadingString = _liveTrackingHelper.GetHeadingStringFromDegrees(data.Heading);

        //    if (data.CompanyId != null)
        //    {
        //        var connectionId = _currentUsers.FirstOrDefault(x => x.Value == data!.CompanyId.Value).Key;
        //        if (connectionId != null)
        //        {
        //            await Clients.Client(connectionId).SendAsync("GpsData", data);
        //        }
        //    }
        //}
        //public override async Task OnConnectedAsync()
        //{
        //    var authenticationType = Context.User!.Identity!.AuthenticationType;

        //    if (authenticationType != "ApiKey")
        //    {
        //        var connectionId = Context.ConnectionId;
        //        int companyId = int.Parse(Context.User!.Claims.Where(x => x.Type == "CompanyId").First().Value);
        //        _currentUsers.Add(connectionId, companyId);
        //    }

        //    await base.OnConnectedAsync();
        //}
        //public override async Task OnDisconnectedAsync(Exception? exception)
        //{
        //    var connectionId = Context.ConnectionId;
        //    _currentUsers.Remove(connectionId);

        //    await base.OnDisconnectedAsync(exception);
        //}
    }
}