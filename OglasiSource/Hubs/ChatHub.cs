using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace OglasiSource.Api.Hubs
{
    [Authorize(AuthenticationSchemes = "ApiKey, Bearer")]
    public class ChatHub : Hub
    {
       
    }
}